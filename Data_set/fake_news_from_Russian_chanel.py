# Load library
import pandas as pd
from bs4 import BeautifulSoup
import codecs

# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 140)
   
def import_data_from_site() -> list:  
    file = codecs.open("Data_set/data/fake_news_from_site.html", "r", "utf-8")
    html = file.read()
    soup = BeautifulSoup(html, features="html.parser")
    # kill all script and style elements
    for script in soup(["script", "style"]):
        script.extract()    # rip it out
    # get text
    text = soup.get_text()
    # break into lines and remove leading and trailing space on each
    lines = (line.strip() for line in text.splitlines())
    # break multi-headlines into a line each
    chunks = (phrase.strip() for line in lines for phrase in line.split("  "))
    # drop blank lines
    text = '\n'.join(chunk for chunk in chunks if chunk)
    splited_text = text.splitlines()
    sorted_text = [s for s in splited_text if ('ФЕЙК' or 'НЕПРАВДА' or 'МАНІПУЛЯЦІЯ') in s]
    # remove useless words
    cleaned_text = {x.replace('ФЕЙК: ', '').replace('НЕПРАВДА: ', '').replace('МАНІПУЛЯЦІЯ: ', '') for x in sorted_text}
    return cleaned_text