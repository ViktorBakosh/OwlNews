import pandas as pd
import spacy
import psycopg2
import psycopg2.extras
nlp = spacy.load("uk_core_news_lg")
STOP_WORDS = spacy.lang.uk.stop_words.STOP_WORDS #assign the default stopwords list to a variable
# Environment settings: 
pd.set_option('display.max_rows', None)
pd.set_option('display.max_colwidth', 210)


arr = []
# hostname = 'localhost'
# database = 'NEWS'
# username = 'postgres'
# password = '123'
hostname = 'owlnews.postgres.database.azure.com'
database = 'vovatest'
username = 'vBakosh'
password = 'OwlDBNews!'
port_id = 5432

conn = None
try:
    with psycopg2.connect(
                host = hostname,
                dbname = database,
                user = username,
                password = password,
                port = port_id) as conn:

        with conn.cursor(cursor_factory=psycopg2.extras.DictCursor) as cur:
            query = """SELECT * FROM public.test
                        ORDER BY id ASC """
            cur.execute(query)
            for record in cur.fetchall():
                arr.append(record['title'])
            
            
except Exception as error:
    print(error)
finally:
    if conn is not None:
        conn.close()

def process_text(text):
    doc = nlp(text.lower())
    result = []
    for token in doc:
        if token.text in nlp.Defaults.stop_words:
            continue
        if token.is_punct:
            continue
        if token.lemma_ == '-PRON-':
            continue
        result.append(token.lemma_)
    return " ".join(result)

def is_dublicate(news : list ,arr: str):  
    search_result = []
    news = nlp(process_text(news))
    dt = pd.DataFrame()
    dt['news'] = arr
    dt['value'] = dt['news'].apply(lambda text: news.similarity(nlp(process_text(text))))
    df = dt.sort_values(by = ['value'])
    print(df)
    for i in range(10):  #кількісить новин, які потрбно вивести
        search_result.append(df.news.iloc[-(i+1)])
    return search_result
news = 'форд збив насмерть чоловіка, Житомир'

print(is_dublicate(news,arr))