<h1>Дипломный проект</h1>
<div style="font-size: large; text-align: justify;">Здравствуйте, друзья! Хочу представить мой первый проект (он же был моим дипломным проектом). Стек технологий, который был использован в процессе написания дипломного проекта:
  <ul>
    <li>HTML;</li>
    <li>CSS;</li>
    <li>JavaScript;</li>
    <li>JQuery;</li>
    <li>ASP.NET FRAMEWORK MVC;</li>
    <li>Entity Framework;</li>
    <li>Kendo MVC UI;</li>
    <li>SQL - куда уж без него:);</li>
    <li>База данных Microsoft Sql Server;</li>
    <li>Система отчетности Sql Server Reporting Service;</li>
    <li>Собственно, и сам мой любимый язык программирования C# :)</li>
  </ul>
Конечно, я не могу гарантировать, что проект мой прямо-таки идеальный. Как говориться: "Нет предела совершенству:)". Но, я старался. У меня не было цели коммерцизировать свой проект. Моя цель была поработать с данным стеком технологий. И своими руками создать что-то свое:). Мой проект представляет собой интернет магазин. Говоря простым языком - сайт, где пользователь может просматривать имеющиеся товары, добавлять в корзину, делать заявку. Если пользователь зарегистрирован, то ему полагается дополнительная скидка в размере 5%. Так.... Что-то я разговорился:) Меньше болтавни:) Пробежимся по интерфейсу:)
<ul>
  <li><a href="#Autentification">Окно входа;</a></li>
  <li><a href="#Registration">Окно регистрации;</a></li>
  <li><a href="#Information">Информация;</a></li>
  <li><a href="#Contact">Контакты;</a></li>
  <li><a href="#Shop">Магазин;</a></li>
  <li><a href="#Recycler">Корзина;</a></li>
</ul>
<h1 id="Autentification">Окно входа</h1>
<p>При старте приложения открывается стартовая страница, где пользователь, если он зарегистрирован на сайте, вводит свой логин и пароль</p>
  
![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/643f987f-7a71-4e18-b6e6-dd60019c35e1)

<p>В случае, если логин или пароль указан не верный, появляется сообщение</p>

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/1f5c045c-fffb-4468-8d9b-0263bdb74f5f)

<h1 id="Registration">Окно регистрации</h1>
<p>Здесь пользователь пожет зарегистрироваться на сайте.</p>

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/15955260-9871-4d14-96e3-c8d086c4eed7)

<p>Имеется небольшая валидация пароля</p>

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/80bfcc23-6882-44ea-b87d-daed26c3fc12)

<h1 id="Information">Информация</h1>

При переходе на эту страницу отображается краткая информация о сайте. В конкретном случае, рассказывается о сайте и какие товары на данном сайте имеются. Фотографии товаров отображаются в специальной карусели bootstrap (https://getbootstrap.com/docs/5.0/components/carousel/)

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/7062a233-e46b-4753-82c7-d6efd6d18031)

<h1 id="Contact">Контакты</h1>

При переходе на эту страницу отображается карта, где указывается ширина и долгота. Собственно, обычно на многих подобных сайтах, занимающихся продажей товаров, реализован подобный функционал :)

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/632ad0d9-768e-49d2-a405-bbbdad9058f9)

<h1 id="Shop">Магазин</h1>

Основная страница, где пользователь может просмотреть имеющиеся товары на сайте. Также доступна панель фильтрации товаров, где пользователь может отобрать товары по критериям (в данном случае цена, поставщик товаров, группа товара). Также можно добавлять товары в корзину.

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/7a7a6bd2-54d2-44d9-b4a2-bbc53077630f)

<h1 id="Recycler">Корзина</h1>

Товары, которые пользователь выбрал на сайте, попадают в корзину. Здесь пользователь может отредактировать количество товара, удалить товар из корзины. Также автоматически подсчитывается итог. При нажатии на кнопку "Отправить заявку" сформированная заявка обрабатывается методом контроллера и сохраняется в специальную таблицу базы данных. Пользователь, имеющий доступ к просмотрам заявок, видит данную заявку.

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/b6e02fa3-da50-409a-9986-0346d6ca135c)


</div>
