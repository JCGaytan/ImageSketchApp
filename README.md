
# Image Sketch Application

This repository contains a Windows Forms application developed in C# that processes an image using a Python script to generate a sketch. The application provides a graphical user interface (GUI) to load an image, process it into a sketch, and display both the original and processed images side by side.

![Pedro alt text](https://github.com/JCGaytan/ImageSketchApp/blob/master/Pedro%20Sketch.jpg)

---

## Application Overview

### Features
- Load an image using a `Load Image` button.
- Generate a sketch of the loaded image using a `Generate Sketch` button.
- View the original image and the processed sketch side-by-side.
- Handles file locking issues by loading images into memory.

### Python Script: `sketch_image.py`
The Python script uses OpenCV to process images.

#### Code:
```python
import sys
import cv2

def generate_sketch(input_path, output_path):
    image = cv2.imread(input_path)
    gray_image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    inverted = 255 - gray_image
    blur = cv2.GaussianBlur(inverted, (21, 21), 0)
    inverted_blur = 255 - blur
    sketch = cv2.divide(gray_image, inverted_blur, scale=256.0)
    cv2.imwrite(output_path, sketch)

if __name__ == "__main__":
    input_path = sys.argv[1]
    output_path = sys.argv[2]
    generate_sketch(input_path, output_path)
```

---

## Windows Forms Application

### Key Methods
#### `btnLoadImage_Click`
Handles loading the image into the `PictureBox`.
```csharp
private void btnLoadImage_Click(object sender, EventArgs e)
{
    using (OpenFileDialog openFileDialog = new OpenFileDialog())
    {
        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            pictureBoxOriginal.Image = new Bitmap(openFileDialog.FileName);
            pictureBoxOriginal.Tag = openFileDialog.FileName;
        }
    }
}
```

#### `btnGenerateSketch_Click`
Executes the Python script and loads the result into the second `PictureBox`.
```csharp
private void btnGenerateSketch_Click(object sender, EventArgs e)
{
    string inputPath = pictureBoxOriginal.Tag.ToString();
    string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "sketch_image.png");

    RunPythonScript("sketch_image.py", inputPath, outputPath);

    if (File.Exists(outputPath))
    {
        using (var stream = new MemoryStream(File.ReadAllBytes(outputPath)))
        {
            pictureBoxSketch.Image = Image.FromStream(stream);
        }
        File.Delete(outputPath);
    }
}
```

---

## How to Run

### Steps
1. Clone this repository.
2. Place the `sketch_image.py` script in the project directory.
3. Build and run the Windows Forms application.
4. Use the `Load Image` button to select an image.
5. Click the `Generate Sketch` button to process the image.

---

# Aplicación de Bocetos de Imágenes

Este repositorio contiene una aplicación de Windows Forms desarrollada en C# que procesa una imagen usando un script de Python para generar un boceto. La aplicación proporciona una interfaz gráfica de usuario (GUI) para cargar una imagen, procesarla en un boceto y mostrar tanto la imagen original como la procesada lado a lado.

![Pedro alt text](https://github.com/JCGaytan/ImageSketchApp/blob/master/Pedro%20Sketch.jpg)
---

## Resumen de la Aplicación

### Características
- Cargar una imagen usando un botón `Cargar Imagen`.
- Generar un boceto de la imagen cargada usando un botón `Generar Boceto`.
- Ver la imagen original y el boceto procesado lado a lado.
- Maneja problemas de bloqueo de archivos cargando imágenes en memoria.

### Script de Python: `sketch_image.py`
El script de Python utiliza OpenCV para procesar imágenes.

#### Código:
```python
import sys
import cv2

def generate_sketch(input_path, output_path):
    image = cv2.imread(input_path)
    gray_image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    inverted = 255 - gray_image
    blur = cv2.GaussianBlur(inverted, (21, 21), 0)
    inverted_blur = 255 - blur
    sketch = cv2.divide(gray_image, inverted_blur, scale=256.0)
    cv2.imwrite(output_path, sketch)

if __name__ == "__main__":
    input_path = sys.argv[1]
    output_path = sys.argv[2]
    generate_sketch(input_path, output_path)
```

---

## Aplicación de Windows Forms

### Métodos Clave
#### `btnLoadImage_Click`
Carga la imagen en el `PictureBox`.
```csharp
private void btnLoadImage_Click(object sender, EventArgs e)
{
    using (OpenFileDialog openFileDialog = new OpenFileDialog())
    {
        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            pictureBoxOriginal.Image = new Bitmap(openFileDialog.FileName);
            pictureBoxOriginal.Tag = openFileDialog.FileName;
        }
    }
}
```

#### `btnGenerateSketch_Click`
Ejecuta el script de Python y carga el resultado en el segundo `PictureBox`.
```csharp
private void btnGenerateSketch_Click(object sender, EventArgs e)
{
    string inputPath = pictureBoxOriginal.Tag.ToString();
    string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "sketch_image.png");

    RunPythonScript("sketch_image.py", inputPath, outputPath);

    if (File.Exists(outputPath))
    {
        using (var stream = new MemoryStream(File.ReadAllBytes(outputPath)))
        {
            pictureBoxSketch.Image = Image.FromStream(stream);
        }
        File.Delete(outputPath);
    }
}
```

---

## Cómo Ejecutar

### Pasos
1. Clone este repositorio.
2. Coloque el script `sketch_image.py` en el directorio del proyecto.
3. Compile y ejecute la aplicación de Windows Forms.
4. Use el botón `Cargar Imagen` para seleccionar una imagen.
5. Haga clic en el botón `Generar Boceto` para procesar la imagen.

---

# Application de Croquis d'Images

Ce dépôt contient une application Windows Forms développée en C# qui traite une image à l'aide d'un script Python pour générer un croquis. L'application fournit une interface utilisateur graphique (GUI) pour charger une image, la traiter en un croquis et afficher côte à côte l'image originale et l'image traitée.

![Pedro alt text](https://github.com/JCGaytan/ImageSketchApp/blob/master/Pedro%20Sketch.jpg)
---

## Aperçu de l'Application

### Fonctionnalités
- Charger une image à l'aide d'un bouton `Charger l'Image`.
- Générer un croquis de l'image chargée à l'aide d'un bouton `Générer un Croquis`.
- Afficher côte à côte l'image originale et le croquis traité.
- Gérer les problèmes de verrouillage des fichiers en chargeant les images en mémoire.

### Script Python: `sketch_image.py`
Le script Python utilise OpenCV pour traiter les images.

#### Code:
```python
import sys
import cv2

def generate_sketch(input_path, output_path):
    image = cv2.imread(input_path)
    gray_image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    inverted = 255 - gray_image
    blur = cv2.GaussianBlur(inverted, (21, 21), 0)
    inverted_blur = 255 - blur
    sketch = cv2.divide(gray_image, inverted_blur, scale=256.0)
    cv2.imwrite(output_path, sketch)

if __name__ == "__main__":
    input_path = sys.argv[1]
    output_path = sys.argv[2]
    generate_sketch(input_path, output_path)
```

---

## Application Windows Forms

### Méthodes Clés
#### `btnLoadImage_Click`
Charge l'image dans le `PictureBox`.
```csharp
private void btnLoadImage_Click(object sender, EventArgs e)
{
    using (OpenFileDialog openFileDialog = new OpenFileDialog())
    {
        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            pictureBoxOriginal.Image = new Bitmap(openFileDialog.FileName);
            pictureBoxOriginal.Tag = openFileDialog.FileName;
        }
    }
}
```

#### `btnGenerateSketch_Click`
Exécute le script Python et charge le résultat dans le deuxième `PictureBox`.
```csharp
private void btnGenerateSketch_Click(object sender, EventArgs e)
{
    string inputPath = pictureBoxOriginal.Tag.ToString();
    string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "sketch_image.png");

    RunPythonScript("sketch_image.py", inputPath, outputPath);

    if (File.Exists(outputPath))
    {
        using (var stream = new MemoryStream(File.ReadAllBytes(outputPath)))
        {
            pictureBoxSketch.Image = Image.FromStream(stream);
        }
        File.Delete(outputPath);
    }
}
```

---

## Comment Exécuter

### Étapes
1. Clonez ce dépôt.
2. Placez le script `sketch_image.py` dans le répertoire du projet.
3. Construisez et exécutez l'application Windows Forms.
4. Utilisez le bouton `Charger l'Image` pour sélectionner une image.
5. Cliquez sur le bouton `Générer un Croquis` pour traiter l'image.
