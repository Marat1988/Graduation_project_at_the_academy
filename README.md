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
  <li><a href="#Autentification">Окно входа</a></li>
  <li><a href="#Registration">Окно регистрации</a></li>
  <li><a href="#Information">Информация</a></li>
  <li><a href="#Contact">Контакты</a></li>
  <li><a href="#Shop">Магазин</a></li>
  <li><a href="#Recycler">Корзина</a></li>
  <li><a href="#Admin">Админ</a>
    <ul>
      <li><a href="#AdminPageStart">Стартовая страница админа</a></li>
      <li><a href="#AdminPanel">Панель администратора</a></li>
      <li><a href="#Users">Пользователи</a></li>
      <li><a href="#Role">Роли</a></li>
      <li><a href="#GroupProduct">Группы товара</a></li>
      <li><a href="#Supplier">Поставщики товара</a></li>
      <li><a href="#Product">Товары</a></li>
      <li><a href="#Order">Заявки</a></li>
    </ul>
  </li>
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

<h1 id="Admin">Админ</h1>

Для входа под пользоватем, обладающим правами администратора, вводим логин Admin, а пароль mypassword

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/d23aba08-9a3c-4081-a015-4fc586d89bb9)

<h1 id="AdminPageStart">Стартовая страница админа</h1>

При входе пользователя появляется его страница профиля. Здесь он может отредактировать свои персональные данные

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/d82f8bfa-b2fa-47f6-b5a3-93b145179f12)

<h1 id="AdminPanel">Панель администратора</h1>

Пользователю, обралающим правами администратора, доступна панель, где он может добавить, изменить, удалить данные по товарам, группам товаров, поставщикам. Также он может просматривать пользователей, зарегистрированных на сайте и, при необходимости, заблокировать пользователя. Также он видит заявки, которые сформировали пользователи.

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/f8553d53-148e-47e4-ba48-dbe3133f1e53)

<h1 id="Users">Пользователи</h1>

Здесь отображаются пользователи, зарегистрированные на сайте. Можно заблокировать пользователя, либо удалить его.

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/55b8d56a-10af-4bcb-93bb-e401cd0e3630)

Также можно изменить данные пользователя (при нажатии на кнопку "Изменить")

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/75f50309-e0d8-4858-b783-6ab4b92d3494)

<h1 id="Role">Роли</h1>

Здесь администратор может повысить пользователя до "админа" или убрать у него полномичия администратора (при нажатии на кнопку "изменить")

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/62d78092-f483-4a0a-8ff1-fc011d8ca57a)

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/e4eef55f-3a9e-4cd9-bfc5-bb07a4449fda)

Также доступна возможность добавить новую роль

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/b5dbd853-0fde-4dd9-93cb-d78905313f98)

<h1 id="GroupProduct">Группы товара</h1>

Здесь доступна возможность добавления, удаления и изменения групп товаров (кнопки добавить, изменить, удалить)

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/26da6294-9fbb-4572-9603-674afbe647d7)

<h1 id="Supplier">Поставщики товара</h1>

Здесь доступна возможность добавления, удаления и изменения поставщиков товара (кнопки добавить, изменить, удалить)

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/f1ebe368-7375-4fa3-a396-a05dd170de71)

<h1 id="Product">Товары</h1>

Здесь отображаются товары, которые есть в базе данных

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/b7831d3d-94e0-4058-b7db-e019f5f0007d)

При надедении курсора мыши на иконку с фотографией можно увидеть фото товара

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/0f30eac6-6b9c-42fa-a095-66b61792d459)

Доступна кнопка добавления, удаления и изменения товара. Также доступе поиск и фильтрация товаров.

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/d8cbe165-991d-4200-b516-ea237299a01a)

При нажатии на кнопку "изменить" открывается диалоговое окно, где можно модифицировать данные о товаре, например изменить название, цену, фотографию, поставщика и т.д.

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/ff259d03-07cd-4493-a92a-6f99506cd5c9)

При нажатии на кнопку "добавить" открывается диалоговое окно, где можно добавить товар

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/3c1b4bd3-ec21-4128-9ff1-5eaa64667d08)

<h1 id="Order">Заявки</h1>

При переходе на даннцю страницу отображаются заявки, которые делали пользователь на сайте

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/f4a1e731-61d4-4ea7-8754-564f2e18f4e6)

Доступен экспорт заявок в Excel, Pdf. При нажатии на кнопку "редактировать" администратор отмечает (ставит чекбокс) состояние заявки - обработана или не обработана.

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/be9796d0-cdd5-4a73-995a-92485f856a16)

При нажатии на ссылку "открыть отчет" появляется страница, где администратор видит состав заявки и может данную заявку распечатать или экспортировать в различные форматы. Вот здесь как раз я и выполнил интергацию Sql Server Reporting Service в приложение Asp.NET Framework. То есть, по сути это открывается отчет из Sql Server Reporting Service, но только в приложении Asp.NET Framework

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/315e8ed5-15bc-4a16-9eab-f7a9930639d3)

![image](https://github.com/Marat1988/Graduation_project_at_the_academy/assets/108996479/5ccf3159-d034-4684-a28d-364f07261e38)




</div>
