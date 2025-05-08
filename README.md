e-Commerce Service
This project is a microservice-based architecture for an eCommerce portal. It includes the following services:

API Gateway (Ocelot)

Product Service (ProductService)

Cart Service (CartService)

Order Service (OrderService)

Services Overview
1. API Gateway (Ocelot)
The API Gateway acts as the entry point for all client requests, routing them to the appropriate microservices.

2. Product Service (ProductService)
Handles product-related operations, including retrieving product details and adding new products.

3. Cart Service (CartService)
Handles operations related to shopping cart management, such as adding/removing products to/from the cart.

4. Order Service (OrderService)
Manages order creation and retrieval after checkout.

URLs for Services
API Gateway:
URL: http://localhost:5005

Product Service:
URL: http://localhost:5039/api/products

Cart Service:
URL: http://localhost:5201/api/cart

Order Service:
URL: http://localhost:5071/api/orders



