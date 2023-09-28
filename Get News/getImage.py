import requests
from bs4 import BeautifulSoup
import os

def download_images(url):

    # Web sitesine GET isteği gönderin
    response = requests.get(url)

    # İstek başarılı olduysa devam edin
    if response.status_code == 200:
        # Sayfa içeriğini BeautifulSoup ile analiz edin
        soup = BeautifulSoup(response.text, 'html.parser')

        # İlk resim etiketini (img) bulun
        first_img = soup.find('img')

        # İlk resmin bağlantısını (src) alın
        if first_img and 'src' in first_img.attrs:
            img_link = first_img['src']
            print(img_link)
            return img_link
        else:
            print('İlk resim bulunamadı veya bağlantı yok.')
    else:
        print('Web sitesine erişim başarısız oldu.')
