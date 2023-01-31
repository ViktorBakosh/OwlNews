import psycopg2
import psycopg2.extras

hostname = 'localhost'
database = 'NEWS'
username = 'postgres'
pwd = '123'
port_id = 5432
conn = None
try:
    with psycopg2.connect(
                host = hostname,
                dbname = database,
                user = username,
                password = pwd,
                port = port_id) as conn:

        with conn.cursor(cursor_factory=psycopg2.extras.DictCursor) as cur:

            cur.execute('DROP TABLE IF EXISTS employee')
            query = """SELECT * FROM public.cherkassy
                        ORDER BY id ASC """
            cur.execute(query)
            for record in cur.fetchall():
                print( record['id'],record['title'])
except Exception as error:
    print(error)
finally:
    if conn is not None:
        conn.close()