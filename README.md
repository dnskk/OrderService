# Order service

This is an ASP.NET Core web-service for working with orders.

# REST API

## Get order by ID

### Request

`GET /Order/{orderId}`

    curl -i -H 'Accept: application/json' http://localhost:60402/Order/Get/1

### Response

    HTTP/1.1 200 OK
    Date: Wed, 29 Jul 2020 16:41:51 GMT
    Status: 200 OK
    Content-Type: application/json

    {"id":1,"status":1,"products":["1","2"],"price":1001,"postamatId":1,"customerPhoneNumber":"+7123-456-78-30","customerFullName":"Ivanov Ivan Ivanovich"}

## Add order

### Request

`POST /Order`

### Response

    HTTP/1.1 200 OK
    Date: Wed, 29 Jul 2020 16:41:51 GMT
    Status: 200 OK
    Content-Type: application/json

    {"id":1,"status":1,"products":["1","2"],"price":1001,"postamatId":1,"customerPhoneNumber":"+7123-456-78-30","customerFullName":"Ivanov Ivan Ivanovich"}

## Update order

### Request

`PUT /Order`

### Response

    HTTP/1.1 200 OK
    Date: Wed, 29 Jul 2020 16:41:51 GMT
    Status: 200 OK
    Content-Type: application/json

    {"id":1,"status":1,"products":["1","2"],"price":1001,"postamatId":1,"customerPhoneNumber":"+7123-456-78-30","customerFullName":"Ivanov Ivan Ivanovich"}

## Cancel order

### Request

`DELETE /Order/{orderId}`

### Response

    HTTP/1.1 200 OK
    Date: Wed, 29 Jul 2020 16:41:51 GMT
    Status: 200 OK
    Content-Type: application/json

    {"id":1,"status":6,"products":["1","2"],"price":1001,"postamatId":1,"customerPhoneNumber":"+7123-456-78-30","customerFullName":"Ivanov Ivan Ivanovich"}

