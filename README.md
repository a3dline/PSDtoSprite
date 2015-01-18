# PSDtoSprite
Adobe Photoshop To Unity Sprite Converter

Автоматически генерирует спрайты по слоям PSD документа. 
Для того чтобы psd файл был обработан необходимо в конец имени файла добавить суффикс atlas.

Для работы с psd форматом была использована открытая библиотека https://github.com/Banbury/UnityPsdImporter/

## Советы
1. Изменить суфикс можно через Window/PSD Import Setting. 
2. Настройки импорта текстуры автоматически выставляются в Sprite Multiplay.
3. Если слой в документе PSD будет вылезать за границу изображения, то Unity выдаст ошибку при импорте.
4. Если переименовать слой в PSD документе, то Unity создаст новый уникальный спрайт. Однако, если вернуть имя обратно, то Unity вернет старый спрайт.

---------------------------------------------------------

Automatically generates Unity Sprites by Layers PSD document.
To psd file has been processed it is necessary to add at the end of the file name suffix "atlas."

To work with psd format open source library was used https://github.com/Banbury/UnityPsdImporter/

## Tips
1. The Changing of the suffix is possible through the Window / PSD Import Setting.
2. Texture import settings is automatically set in the Sprite Multiplay.
3. If the layer in the PSD document will come out of image abroad, the Unity will generate an error while importing.
4. If you rename a layer in the PSD document, Unity will create new and unique sprite. However, if you return the name back then Unity returns the old sprite.
