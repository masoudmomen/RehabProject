// Homepage hero: floating motes of light around the hands + gentle pointer parallax.
// Loaded as an ES module from HeroSection.razor; purely decorative.

let cleanup = null;

export function initialize(scene) {
    dispose();
    if (!scene || matchMedia('(prefers-reduced-motion: reduce)').matches) return;

    const cv = scene.querySelector('.hero-motes');
    const ctx = cv.getContext('2d');
    let W = 0, H = 0, motes = [], rafMotes = 0, rafParallax = 0;

    function spawn(init) {
        // cluster loosely around the gap between the hands (74%, 35%)
        const a = Math.random() * Math.PI * 2, r = Math.pow(Math.random(), .7) * W * .16;
        return {
            x: W * .742 + Math.cos(a) * r * 1.3, y: H * .35 + Math.sin(a) * r + (init ? 0 : H * .08),
            vx: (Math.random() - .5) * .08, vy: -(.05 + Math.random() * .12), r: .8 + Math.random() * 2.2,
            life: init ? Math.random() : 0, speed: .0012 + Math.random() * .0018, tw: Math.random() * 6
        };
    }

    function size() {
        const dpr = Math.min(devicePixelRatio || 1, 2);
        W = scene.clientWidth; H = scene.clientHeight;
        cv.width = W * dpr; cv.height = H * dpr;
        ctx.setTransform(dpr, 0, 0, dpr, 0, 0);
        motes = Array.from({ length: 26 }, () => spawn(true));
    }

    let last = performance.now();
    function frame(t) {
        const dt = Math.min(t - last, 50); last = t;
        ctx.clearRect(0, 0, W, H);
        for (let i = 0; i < motes.length; i++) {
            const m = motes[i];
            m.life += m.speed * dt / 16; m.x += m.vx * dt / 16; m.y += m.vy * dt / 16; m.tw += .02 * dt / 16;
            if (m.life >= 1) { motes[i] = spawn(false); continue; }
            const fade = Math.sin(m.life * Math.PI) * (.55 + .45 * Math.sin(m.tw));
            const g = ctx.createRadialGradient(m.x, m.y, 0, m.x, m.y, m.r * 4);
            g.addColorStop(0, `rgba(255,252,246,${.9 * fade})`);
            g.addColorStop(1, 'rgba(255,240,235,0)');
            ctx.fillStyle = g; ctx.beginPath(); ctx.arc(m.x, m.y, m.r * 4, 0, 6.283); ctx.fill();
        }
        rafMotes = requestAnimationFrame(frame);
    }

    size();
    addEventListener('resize', size);
    rafMotes = requestAnimationFrame(frame);

    // pointer parallax, desktop only
    let onMove = null;
    if (matchMedia('(pointer: fine)').matches) {
        const layers = [...scene.querySelectorAll('[data-depth]')];
        let tx = 0, ty = 0, cx = 0, cy = 0;
        onMove = e => { tx = e.clientX / innerWidth - .5; ty = e.clientY / innerHeight - .5; };
        addEventListener('pointermove', onMove);
        (function loop() {
            cx += (tx - cx) * .04; cy += (ty - cy) * .04;
            for (const l of layers) {
                const d = +l.dataset.depth;
                l.style.translate = `${(-cx * d * .9).toFixed(2)}px ${(-cy * d * .6).toFixed(2)}px`;
            }
            rafParallax = requestAnimationFrame(loop);
        })();
    }

    cleanup = () => {
        cancelAnimationFrame(rafMotes);
        cancelAnimationFrame(rafParallax);
        removeEventListener('resize', size);
        if (onMove) removeEventListener('pointermove', onMove);
    };
}

export function dispose() {
    if (cleanup) { cleanup(); cleanup = null; }
}
