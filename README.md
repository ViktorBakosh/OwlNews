﻿# Instruction

to launch site(html file) you need to do it in http-server and open via http request

if you want do without it the easiest is to install http-server globally using node's package manager:

## For Windows

- run ```npm install -g http-server```
- Then simply run ```http-server``` in any of your project directories: Eg. d:\my_project> http-server
- then copy one of links in console and past it into your browser example of links in console:
```
Available on:
    http://192.168.1.9:8080
    http://127.0.0.1:8080
    http://127.0.2.2:8080
    http://127.0.2.3:8080
Hit CTRL-C to stop the server
```
## For Linux 

- Since Python is usually available in most linux distributions, just run python -mSimpleHTTPServer in your project directory, and you can load your page on http:/localhost:8000
- In Python 3 the SimpleHTTPServer module has been merged into http.server, so the newcommand is python3 -m http.server.
- Easy, and no security risk of accidentally leaving your browser open vulnerable.
