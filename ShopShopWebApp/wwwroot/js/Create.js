// createAdsDto instance from partitial page

// Отримати всі елементи з класом 'image-upload'
const fileInputs = document.querySelectorAll('.image-upload');

fileInputs.forEach(function(input) {
    input.addEventListener('change', function(event) {
        if (event.target.files.length > 0) {
            let selectedFile = event.target.files[0];
            let imageURL = URL.createObjectURL(selectedFile);
            // Отримати батьківський елемент (label) для зображення
            let label = input.parentElement.querySelector('label');
            // Змінити фонове зображення label на завантажене зображення
            if (label != null) {
                label.style.backgroundImage = `url(${imageURL})`;
                label.parentElement.querySelector('i').remove();
            }
        } else {
            console.log('Користувач не обрав файл');
        }
    });
});
