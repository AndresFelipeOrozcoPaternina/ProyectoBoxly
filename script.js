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

document.addEventListener('DOMContentLoaded', () => {
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
});
