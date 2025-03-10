function getStoredTheme(): string {
    return localStorage.getItem('theme');
}

function setStoredTheme(theme: string): void {
    localStorage.setItem('theme', theme);
}

function getPreferredTheme(): string {
    const storedTheme = getStoredTheme();
    if (storedTheme) {
        return storedTheme;
    }

    return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
}

function setTheme(theme: string): void {
    if (theme === 'auto') {
        document.documentElement.setAttribute('data-bs-theme', (window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light'));
    } else {
        document.documentElement.setAttribute('data-bs-theme', theme);
    }
}

function listenForPreferredSchemeChanges(): void {
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', () => {
        const storedTheme = getStoredTheme();
        if (storedTheme !== 'light' && storedTheme !== 'dark') {
            setTheme(getPreferredTheme());
        }
    });
}

function listenForThemeChanges(): void {
    document.querySelectorAll('[data-bs-theme-value]')
        .forEach(toggle => {
            toggle.addEventListener('click', () => {
                const theme = toggle.getAttribute('data-bs-theme-value');
                setStoredTheme(theme);
                setTheme(theme);
                setThemeActive(theme, true);
            });
        });
}

function setThemeActive(theme: string, focus: boolean = false) {
    const themeSwitcher = document.querySelector('#bd-theme') as HTMLElement;

    if (themeSwitcher === null) {
        return;
    }

    const activeThemeIcon = document.querySelector('.theme-icon-active i');
    const btnToActive = document.querySelector(`[data-bs-theme-value="${theme}"]`);
    const spanOfActiveBtn = btnToActive.querySelector('span i').getAttribute('class');

    document.querySelectorAll('[data-bs-theme-value]').forEach(element => {
        element.classList.remove('active');
    })

    btnToActive.classList.add('active');
    activeThemeIcon.setAttribute('class', spanOfActiveBtn);

    if (focus) {
        themeSwitcher.focus();
    }
}

export function initializeTheming(): void {
    setTheme(getPreferredTheme());
    listenForPreferredSchemeChanges();

    window.addEventListener('DOMContentLoaded', () => {
        setThemeActive(getPreferredTheme());
        listenForThemeChanges();
    });
}