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
