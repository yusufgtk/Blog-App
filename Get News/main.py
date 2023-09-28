from ai import *
from request import *
from titleRequest import *
from getrss import *
from translate import *
from getImage import *
import sqlite3
from datetime import datetime

url=input('Web sayfasının url\'ini giriniz : ')
kaynak=input("haber kaynağı : ")
links=getRss(url)

for link in links:
    text1=WebRequest(link)
    title=WebRequestTitle(link)
    imageUrl=download_images(link)
    if imageUrl==None:
        imageUrl = "https://pbs.twimg.com/profile_images/1634144208096317440/qM7Xa0LI_400x400.jpg"



    text_summaries=TextSummarizer(text1,200,150)
    print(len(text_summaries))
    sharedHistory=datetime.now()


    # database connection
    conn=sqlite3.connect("C:\\Users\\yusuf\\OneDrive\\Masaüstü\\Blog Site\\BlogSite.db")
    cursor = conn.cursor()
    cursor.execute('''CREATE TABLE IF NOT EXISTS News (
                        Id INTEGER PRIMARY KEY,
                        CategoryId INTEGER,
                        Title TEXT,
                        Content TEXT,
                        ImageUrl TEXT,
                        Source TEXT,
                        Url TEXT,
                        CreatedAt TEXT
                    )''')
    cursor.execute("INSERT INTO News (CategoryId, Title, Content, ImageUrl, Source, Url, CreatedAt) VALUES (?, ?, ?, ?, ?, ?, ?)",(2, title, text_summaries, imageUrl, kaynak, link,str(sharedHistory)))

    conn.commit()
    # Bağlantıyı kapatın.
    conn.close()
