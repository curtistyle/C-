
from pdf2image import convert_from_path
import os

# Create a folder to dump the jpegs
os.makedirs("jpegs", exist_ok=True)

pages = convert_from_path('JavaScript for Kids.pdf', first_page=1,last_page=2,fmt='jpeg', output_file='page', paths_only=True,output_folder="jpegs")