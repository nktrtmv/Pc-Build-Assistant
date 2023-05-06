Для запуска приложения необходимо ввести в терминале: docker-compose up -d

---------

Для запуска frontend необходимо ввести следующие команды в терминале в папке "frontend":

1. docker build -t app-image .
2. docker run -p 63342:80 app-image

Далее необходимо перейти по ссылке http://localhost:63342
