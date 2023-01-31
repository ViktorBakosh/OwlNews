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
            query = """SELECT * FROM public.cherkassy
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
    news = nlp(process_text(news))
    df = pd.DataFrame()
    df['news'] = arr
    df['value'] = df['news'].apply(lambda text: news.similarity(nlp(process_text(text))))
    df.sort_values(by=['value'], inplace = True)
    if any(df['value'] > 0.75):
        return True
    else: 
        return False
news = 'Злата Огнєвіч на день народження наважилась на важливий крок і дізналась майбутнє'

print(is_dublicate(news,arr))