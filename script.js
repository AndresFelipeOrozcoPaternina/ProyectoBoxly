const CATALOGO = {
    'gamer-ultimate': {
        nombre: 'Caja gamer ultimate',
        categoria: 'Gaming',
        precioMensual: 135000,
        rating: '4.8',
        imagen: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRoPr61I1wZ9vVp-bfg2llh6Kd_MOY3qx7Y9vqLg1ZC4A&s=10',
        descripcion: 'La caja definitiva para amantes del gaming: accesorios, merchandising y snacks seleccionados cada mes para vivir la experiencia completa de tus lanzamientos favoritos.',
        inclusiones: [
            'Mousepad XL de edición',
            'Figura coleccionable',
            'Snacks gamer premium',
            'Accesorio USB sorpresa',
            'Stickers exclusivos'
        ]
    },
    'fitbox-mensual': {
        nombre: 'Fitbox mensual',
        categoria: 'Fitness',
        precioMensual: 120000,
        rating: '4.8',
        imagen: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQqZD1C6DElaUq8b3KQZa9OWRSltXfvpCLpLhW3Bk2Avg&s=10',
        descripcion: 'Kit mensual con suplementos, accesorios deportivos y elementos para entrenar en casa o en el gimnasio con mayor comodidad, seguridad y variedad.',
        inclusiones: [
            'Suplemento o pre-entreno',
            'Botella deportiva',
            'Bandas de resistencia',
            'Snacks proteicos',
            'Guillas de entrenamiento'
        ]
    },
    'cuidado-bienestar': {
        nombre: 'Cuidado y bienestar',
        categoria: 'Cuidado personal',
        precioMensual: 120000,
        rating: '4.8',
        imagen: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4hlipP6Nzf61W2_VHdRVjMIqjkZiMuyCTW3o67RSCrQ&s=10',
        descripcion: 'Productos de higiene, cuidado personal y bienestar para mantener una rutina completa cada mes con artículos premium y útiles de uso diario.',
        inclusiones: [
            'Exfoliante corporal',
            'Vela aromática',
            'Mascarilla facial',
            'Aceite esencial',
            'Té relajante'
        ]
    },
    'techbox-premium': {
        nombre: 'Techbox premium',
        categoria: 'Tecnología',
        precioMensual: 200000,
        rating: '4.9',
        imagen: 'https://images.unsplash.com/photo-1518770660439-4636190af475?auto=format&fit=crop&w=900&q=80',
        descripcion: 'Suscripción con gadgets, accesorios y productos tecnológicos para potenciar tu espacio digital y mantenerte al día con cada lanzamiento del mundo tech.',
        inclusiones: [
            'Power bank 10.000 mAh',
            'Cable USB-C premium',
            'Soporte de celular',
            'Hub USB compacto',
            'Stickers tech'
        ]
    }
};

const PLANES = {
    mensual: { label: 'Mensual', meses: 1, descuento: 0 },
    semestral: { label: 'Semestral', meses: 6, descuento: 0.10 },
    anual: { label: 'Anual', meses: 12, descuento: 0.20 }
};

const COSTO_ENVIO = 15000;
const ALMACEN_SUSCRIPCIONES = 'boxly_suscripciones';

function formatearCOP(valor) {
    return `${Number(valor).toLocaleString('es-CO')} COP`;
}

function calcularValorPlan(precioMensual, planKey) {
    const plan = PLANES[planKey] || PLANES.mensual;
    const bruto = precioMensual * plan.meses;
    const ahorro = Math.round(bruto * plan.descuento);
    const total = bruto - ahorro;

    return {
        label: plan.label,
        meses: plan.meses,
        descuento: plan.descuento,
        bruto,
        ahorro,
        total,
        equivalenteMensual: Math.round(total / plan.meses)
    };
}

function obtenerSuscripcionesGuardadas() {
    try {
        const datos = JSON.parse(localStorage.getItem(ALMACEN_SUSCRIPCIONES) || '[]');
        return Array.isArray(datos) ? datos : [];
    } catch (error) {
        return [];
    }
}

function guardarSuscripcion(suscripcion) {
    const suscripciones = obtenerSuscripcionesGuardadas();
    suscripciones.push(suscripcion);
    localStorage.setItem(ALMACEN_SUSCRIPCIONES, JSON.stringify(suscripciones));
}

function updateSubscriptionFilterCounts() {
    const cards = document.querySelectorAll('.subscription-card');
    const filterButtons = document.querySelectorAll('.filter-pill');
    const totals = {
        all: cards.length,
        active: 0,
        upcoming: 0,
        inactive: 0
    };

    cards.forEach((card) => {
        const status = card.dataset.status;
        if (totals[status] !== undefined) {
            totals[status] += 1;
        }
    });

    filterButtons.forEach((button) => {
        const status = button.dataset.status || 'all';
        const count = totals[status] ?? 0;
        const label = button.textContent.split('(')[0].trim();
        button.innerHTML = `${label} <span>(${count})</span>`;
    });
}

function applySubscriptionFilter(status) {
    const cards = document.querySelectorAll('.subscription-card');
    const filterButtons = document.querySelectorAll('.filter-pill');

    cards.forEach((card) => {
        const matches = status === 'all' || card.dataset.status === status;
        card.style.display = matches ? '' : 'none';
    });

    filterButtons.forEach((button) => {
        button.classList.toggle('active', (button.dataset.status || 'all') === status);
    });
}

window.applySubscriptionFilter = applySubscriptionFilter;

window.updateSubscriptionFilterCounts = updateSubscriptionFilterCounts;

function crearTarjetaSuscripcion(suscripcion) {
    const article = document.createElement('article');
    article.className = 'card subscription-card';
    article.dataset.status = suscripcion.estado || 'active';
    article.dataset.title = suscripcion.nombre;
    article.dataset.description = suscripcion.descripcion || 'Suscripción activada desde el catálogo Boxly.';
    article.dataset.price = `${formatearCOP(suscripcion.precioMensual)} / mes`;

    article.innerHTML = `
        <button class="favorite-btn" type="button" aria-label="Agregar a favoritos">♡</button>
        <div class="card-image-container">
            <img src="${suscripcion.imagen}" alt="${suscripcion.nombre}" class="card-img">
        </div>
        <div class="card-body">
            <h3>${suscripcion.nombre}</h3>
            <div class="card-meta">
                <span class="status active">Activo</span>
                <span class="price">${formatearCOP(suscripcion.precioMensual)}</span>
            </div>
            <button class="details-btn" type="button">Ver detalles</button>
        </div>
    `;

    return article;
}

function inyectarSuscripcionesGuardadas() {
    const grid = document.querySelector('.subscriptions-grid');
    if (!grid) {
        return;
    }

    const suscripciones = obtenerSuscripcionesGuardadas();
    suscripciones.forEach((suscripcion) => {
        if (!suscripcion || !suscripcion.nombre) {
            return;
        }
        grid.appendChild(crearTarjetaSuscripcion(suscripcion));
    });
}

function initDetalleCaja() {
    const params = new URLSearchParams(window.location.search);
    const slug = params.get('caja');
    const caja = CATALOGO[slug] || CATALOGO['gamer-ultimate'];
    const slugResuelto = CATALOGO[slug] ? slug : 'gamer-ultimate';

    const imagen = document.getElementById('detalleImagen');
    const titulo = document.getElementById('detalleTitulo');
    const categoria = document.getElementById('detalleCategoria');
    const rating = document.getElementById('detalleRating');
    const descripcion = document.getElementById('detalleDescripcion');
    const inclusiones = document.getElementById('detalleInclusiones');

    if (imagen) {
        imagen.src = caja.imagen;
        imagen.alt = caja.nombre;
    }
    if (titulo) {
        titulo.textContent = caja.nombre;
    }
    if (categoria) {
        categoria.textContent = caja.categoria;
    }
    if (rating) {
        rating.textContent = `⭐ ${caja.rating}`;
    }
    if (descripcion) {
        descripcion.textContent = caja.descripcion;
    }
    if (inclusiones) {
        inclusiones.innerHTML = caja.inclusiones.map((item) => `<li>${item}</li>`).join('');
    }

    const opciones = document.querySelectorAll('.plan-option input[name="plan"]');
    const resumenPlan = document.getElementById('resumenPlanNombre');
    const resumenValor = document.getElementById('resumenValor');
    const resumenAhorro = document.getElementById('resumenAhorro');
    const resumenTotal = document.getElementById('resumenTotal');

    const actualizarResumen = () => {
        const seleccion = document.querySelector('input[name="plan"]:checked');
        const planKey = seleccion ? seleccion.value : 'mensual';
        const calculo = calcularValorPlan(caja.precioMensual, planKey);

        document.querySelectorAll('.plan-option').forEach((opcion) => {
            const input = opcion.querySelector('input');
            opcion.classList.toggle('selected', Boolean(input && input.checked));
        });

        if (resumenPlan) {
            resumenPlan.textContent = `Plan ${calculo.label} (${calculo.meses} ${calculo.meses === 1 ? 'mes' : 'meses'})`;
        }
        if (resumenValor) {
            resumenValor.textContent = formatearCOP(calculo.bruto);
        }
        if (resumenAhorro) {
            resumenAhorro.textContent = calculo.ahorro > 0 ? `-${formatearCOP(calculo.ahorro)}` : '—';
        }
        if (resumenTotal) {
            resumenTotal.textContent = formatearCOP(calculo.total);
        }
    };

    opciones.forEach((opcion) => {
        opcion.addEventListener('change', actualizarResumen);
    });
    actualizarResumen();

    const btnContinuar = document.getElementById('btnContinuar');
    if (btnContinuar) {
        btnContinuar.addEventListener('click', () => {
            const seleccion = document.querySelector('input[name="plan"]:checked');
            const planKey = seleccion ? seleccion.value : 'mensual';
            window.location.href = `facturacion.html?caja=${encodeURIComponent(slugResuelto)}&plan=${encodeURIComponent(planKey)}`;
        });
    }
}

function initFacturacion() {
    const params = new URLSearchParams(window.location.search);
    const slug = params.get('caja');
    const planKey = PLANES[params.get('plan')] ? params.get('plan') : 'mensual';
    const caja = CATALOGO[slug] || CATALOGO['gamer-ultimate'];
    const calculo = calcularValorPlan(caja.precioMensual, planKey);

    const nombreCaja = document.getElementById('factCajaNombre');
    const planCaja = document.getElementById('factPlanNombre');
    const imagenCaja = document.getElementById('factCajaImagen');
    const valorPlan = document.getElementById('factValorPlan');
    const ahorroPlan = document.getElementById('factAhorroPlan');
    const filaAhorro = document.getElementById('factFilaAhorro');
    const costoEnvio = document.getElementById('factEnvio');
    const total = document.getElementById('factTotal');

    if (nombreCaja) {
        nombreCaja.textContent = caja.nombre;
    }
    if (planCaja) {
        planCaja.textContent = `Plan ${calculo.label} · ${calculo.meses} ${calculo.meses === 1 ? 'mes' : 'meses'}`;
    }
    if (imagenCaja) {
        imagenCaja.src = caja.imagen;
        imagenCaja.alt = caja.nombre;
    }
    if (valorPlan) {
        valorPlan.textContent = formatearCOP(calculo.total);
    }
    if (ahorroPlan) {
        ahorroPlan.textContent = `-${formatearCOP(calculo.ahorro)}`;
    }
    if (filaAhorro) {
        filaAhorro.style.display = calculo.ahorro > 0 ? 'flex' : 'none';
    }
    if (costoEnvio) {
        costoEnvio.textContent = formatearCOP(COSTO_ENVIO);
    }
    if (total) {
        total.textContent = formatearCOP(calculo.total + COSTO_ENVIO);
    }

    const formulario = document.getElementById('formFacturacion');
    if (formulario) {
        formulario.addEventListener('submit', (event) => {
            event.preventDefault();

            if (!formulario.checkValidity()) {
                formulario.reportValidity();
                return;
            }

            guardarSuscripcion({
                id: Date.now(),
                slug: CATALOGO[slug] ? slug : 'gamer-ultimate',
                nombre: caja.nombre,
                imagen: caja.imagen,
                descripcion: caja.descripcion,
                plan: planKey,
                planLabel: calculo.label,
                precioMensual: caja.precioMensual,
                estado: 'active',
                fecha: new Date().toISOString()
            });

            window.location.href = 'cajas.html?nueva=1';
        });
    }
}

function initBannerExito() {
    const banner = document.getElementById('exitoBanner');
    if (!banner) {
        return;
    }

    const params = new URLSearchParams(window.location.search);
    if (params.get('nueva') === '1') {
        banner.classList.remove('hidden');
    }
}

document.addEventListener('DOMContentLoaded', () => {
    inyectarSuscripcionesGuardadas();

    const homeTagButtons = document.querySelectorAll('.tag');
    const homeCards = document.querySelectorAll('.card[data-category]');

    if (homeTagButtons.length && homeCards.length) {
        homeTagButtons.forEach((button) => {
            button.addEventListener('click', () => {
                const filter = button.dataset.filter || 'all';

                homeTagButtons.forEach((tag) => {
                    tag.classList.toggle('active', tag === button);
                });

                homeCards.forEach((card) => {
                    const category = card.dataset.category || 'all';
                    const shouldShow = filter === 'all' || category === filter;
                    card.style.display = shouldShow ? '' : 'none';
                });
            });
        });
    }

    const catalogoCards = document.querySelectorAll('.card[data-slug]');
    catalogoCards.forEach((card) => {
        card.style.cursor = 'pointer';
        card.addEventListener('click', () => {
            window.location.href = `detalle.html?caja=${encodeURIComponent(card.dataset.slug)}`;
        });
    });

    const modal = document.getElementById('subscriptionModal');
    const modalTitle = document.getElementById('modalTitle');
    const modalDescription = document.getElementById('modalDescription');
    const modalPrice = document.getElementById('modalPrice');
    const modalImage = document.getElementById('modalImage');
    const closeButton = document.querySelector('.close-modal');
    const cards = document.querySelectorAll('.subscription-card');
    const detailsButtons = document.querySelectorAll('.details-btn');
    const filterButtons = document.querySelectorAll('.filter-pill');

    updateSubscriptionFilterCounts();
    applySubscriptionFilter('all');

    const openModal = (card) => {
        if (!card || !modal) return;

        const title = card.dataset.title || 'Caja';
        const description = card.dataset.description || 'Sin descripción disponible.';
        const price = card.dataset.price || 'Precio no disponible';
        const image = card.querySelector('img')?.src || '';

        modalTitle.textContent = title;
        modalDescription.textContent = description;
        modalPrice.textContent = price;
        modalImage.src = image;
        modalImage.alt = title;
        modal.classList.remove('hidden');
        modal.setAttribute('aria-hidden', 'false');
    };

    const closeModal = () => {
        if (!modal) return;

        modal.classList.add('hidden');
        modal.setAttribute('aria-hidden', 'true');
    };

    cards.forEach((card) => {
        card.addEventListener('click', (event) => {
            if (event.target.closest('.favorite-btn') || event.target.closest('.details-btn')) {
                return;
            }
            openModal(card);
        });
    });

    detailsButtons.forEach((button) => {
        button.addEventListener('click', () => {
            const card = button.closest('.subscription-card');
            openModal(card);
        });
    });

    if (closeButton) {
        closeButton.addEventListener('click', closeModal);
    }

    if (modal) {
        modal.addEventListener('click', (event) => {
            if (event.target === modal) {
                closeModal();
            }
        });
    }

    document.addEventListener('keydown', (event) => {
        if (event.key === 'Escape' && modal && !modal.classList.contains('hidden')) {
            closeModal();
        }
    });

    filterButtons.forEach((button) => {
        button.addEventListener('click', () => {
            const status = button.dataset.status || 'all';
            applySubscriptionFilter(status);
        });
    });

    updateSubscriptionFilterCounts();
    applySubscriptionFilter('all');

    initBannerExito();

    if (document.body.classList.contains('pagina-detalle')) {
        initDetalleCaja();
    }

    if (document.body.classList.contains('pagina-facturacion')) {
        initFacturacion();
    }

    const btnCanjear = document.querySelectorAll('.bono-btn[data-bono]');
    btnCanjear.forEach((button) => {
        button.addEventListener('click', () => {
            const card = button.closest('.bono-card');
            const estado = card ? card.querySelector('.bono-estado') : null;
            if (estado) {
                estado.className = 'bono-estado canjeado';
                estado.textContent = 'Canjeado';
            }
            button.disabled = true;
            button.textContent = 'Canjeado';
        });
    });
});
