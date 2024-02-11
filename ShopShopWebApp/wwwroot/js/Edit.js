// editAdsDto instance from partitial page
let $imageDiv = $('.card');
let myForm = document.forms[0];
let currentUrl = window.location.origin + '/Advertisements/Edit';

// Шаблон для пустого зображення 
function createEmptyPictureElement() {
    let element = document.createElement('i');
    element.classList.add('bi', 'bi-camera', 'align-middle');
    return element;
}

//Шаблон для зображення з картинкою
function createPictureElement(srcValue) {  
    let element = document.createElement('img');
    element.src = srcValue;
    element.alt = 'Ads Picture';
    element.className = 'card-img-top';
    return element;
}

// Шаблон для кнопки видалення зображення
function createDeleteImgBtn() {
    // Створюємо елемент кнопки
    var button = document.createElement('button');
    // Додаємо класи до кнопки
    button.classList.add('btn', 'btn-secondary', 'btn-show', 'position-absolute');
    // Вказуємо ім'я кнопки
    button.name = 'deleteImgBtn';
    button.type = "button";
    // Встановлюємо стилі для кнопки
    button.style.display = 'none';
    button.style.top = '50%';
    button.style.left = '50%';
    button.style.transform = 'translate(-50%, -50%)';
    // Створюємо елемент іконки для кнопки
    var icon = document.createElement('i');
    // Додаємо класи для іконки
    icon.classList.add('bi', 'bi-trash3');
    // Додаємо іконку до кнопки
    button.appendChild(icon);
    // Повертаємо створений елемент кнопки
    return button;
}

//Шаблон для файлового інпуту
function createFileInputElement(){
    let fileInput = document.createElement("input");
    fileInput.type = "file";
    $('fileInput').attr("disabled", true);
    $('fileInput').attr("class", "image-upload");
    $('fileInput').attr("accept", "image/*");
    $('fileInput').attr("onchange", "previewImage(event)");
    return fileInput;
}

// Масив нових зображень
let newPhotos = [];
let urlPhotosForDelete = [];

//Логіка при відправці форми
myForm.addEventListener('submit', function (event) {
    event.preventDefault(); 

    // let formData = new FormData(editAdsDto);
    // formData.append('NewAdvertisePictures', newPhotos);

    let formData = new FormData();
    
    // Додайте дані з об'єкта Model до FormData
    Object.entries(editAdsDto).forEach(([key, value]) => {
        formData.append(key, value);
    });

    // Отримайте всі дані з форми і оновіть FormData
    let formElements = myForm.elements;
    for (let i = 0; i < formElements.length; i++) {
        let element = formElements[i];
        if (formData.has(element.name.toLowerCase()) && element.type !== 'file' && element.type === 'number') {
            formData.set(element.name.toLowerCase(), parseFloat(element.value));
        }
        else if (formData.has(element.name.toLowerCase()) && element.type !== 'file') {
            formData.set(element.name.toLowerCase(), element.value);
        }
    }
    // Додайте файли з вашої локальної змінної до FormData
    newPhotos.forEach(function (file) {
        formData.append('newAdvertisePictures', file);
    });
    // Додати зображення для видалення
    if (urlPhotosForDelete != null)
    urlPhotosForDelete.forEach(function (url) {
        formData.append('deletedAdvertisePicturesUrls', url);
    })
    else formData.delete('deletedAdvertisePicturesUrls')

    fetch(currentUrl, {
        method: 'POST',
        body: formData
      })
      .then(response => {
        if (response.redirected) {
          window.location.href = response.url; // Перенаправлення на новий URL
        }
      })
      .catch(error => {
        console.error('Помилка відправки на сервер:', error);
      });
});

// Логіка вибору зображення
// Спрацьовує лише якщо в середині елемент <i>
$imageDiv.on('click', function (event) {
    let $element = $($(this).children().first());
    let $thisCard = $(this);
    let tagName = $element.prop('tagName');
    if (tagName.toLowerCase() === 'i') {
        let fileInput = createFileInputElement();
        // Додаємо fileInput до DOM
        document.body.appendChild(fileInput);
        // Обробник на файловий інпут
        fileInput.addEventListener('change', function(event) {
            if (event.target.files.length > 0) {
                let selectedFile = event.target.files[0];
                // Змінюємо елемент, на якому спрацювала подія з пустого зображення на картинку, яка була завантажена
                // Спочатку створюємо новий елемент картинки <img>
                let imageURL = URL.createObjectURL(selectedFile);
                let newImgElement = createPictureElement(imageURL);
                // Далі змінюємо старий <i> на <img>
                $element.replaceWith(newImgElement);
                $thisCard.append(createDeleteImgBtn());
                resubscribeDeleteBtnHide();
                resubscribeCardsOnEvent($thisCard);
                // Збереження URL, щоб пізніше видалити його (необов'язково, але рекомендовано)
                selectedFile.previewURL = imageURL;
                
                newPhotos.push(selectedFile);
            } else {
                console.log('Користувач не обрав файл');
            }
        });
        // Викликаємо клік на fileInput
        fileInput.click();
        fileInput.remove();
    }
});

function resubscribeDeleteBtnHide() {
    $(document).ready(function () {
        $('.card-img-top').hover(
            function () {
                $(this).next('.btn-show').show();
            },
            function () {
                $(this).next('.btn-show').hide();
            }
        );
        $('.btn-show').hover(
            function () {
                $(this).show();
            },
            function () {
                $(this).hide();
            }
        );
    });
}
resubscribeDeleteBtnHide();
function resubscribeCardsOnEvent($cardElement) {
    $cardElement.children('button[name="deleteImgBtn"]').on('click', deleteImage);
};

function deleteImage(event) {
    event.stopPropagation(); // Зупинити подальше поширення події

    let $cardElement =  $($(this).closest('.card'));
    // Отримати URL фотографії з батьківського елемента кнопки видалення
    let imageUrl = $cardElement.find('img').attr('src');

    // Знаходимо індекс фотографії у масиві newPhotos за URL
    let indexToRemove = newPhotos.findIndex(function(picture) {
        return picture.previewURL === imageUrl;
    });
    if (indexToRemove !== -1) {
        // Видаляємо фотографію з масиву newPictures за індексом
        newPhotos.splice(indexToRemove, 1);
    } 
    // Якщо зображення з сервера
    else if (imageUrl !== null) {
        urlPhotosForDelete.push(imageUrl);
    }
    else {
        console.log('Фотографія для видалення не знайдена.');
    }  
    // Видаляємо всі елементи в картці
    $cardElement.empty();
    // Створюємо новий елемент та вставляємо його на місце видалених елементів
    var newCard = createEmptyPictureElement();
    $cardElement.append(newCard);
}
$('button[name="deleteImgBtn"]').on('click', deleteImage);
