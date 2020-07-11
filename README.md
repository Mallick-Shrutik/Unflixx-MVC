# Unflixx-MVC
This is a Video Rental portal where we can keep a list of number of customers and number of movies individually.
We can also keep a track of movies rented by each customer.

We can Create/Add a new Movie or Customer to the list, Read them and Update any Movie/Customer if needed and also we can Delete the unwanted Customer/Movie from the list.

Besides CRUD operation, we have some business rules as follow
a)Each customer can rent multiple movies and each movie can be rented by multiple customers(Many to one and One to Many Relation)
b)For customers opting for Monthly or Quarterly subscription, they have to be atleast 18 years old.
c)Only the admin can Add and/or Delete Movies & Customers and other staff members have read-only access.
d)Number of copies of a particular movie must be between 1 to 20

The project uses HTTP protocols for CRUD operation with the help of jQuery and AJAX.

Admin and staff members can also login using Facebook along with Email(Two factor authentication disbled in the first version)

This project also uses plugins like Datatables(To add pagination and sorting), Typeahead and Bootbox/Bootstrap.

Entity Framework is used to connect to the database.

Code first approach is used in this project.

Along with MVC, RESTful service are used to build the project.
