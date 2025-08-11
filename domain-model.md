| Classes     | Methods                                   | Scenarios                                                               | Outputs/Action      |
| ----------- | ----------------------------------------- | ----------------------------------------------------------------------- | ------------------- |
| `Basket`    | `addItem(Item item)`                      | Add a bagel to basket when space is available                           | Item added          |
|             |                                           | Add a bagel when basket is full                                         | Error: basket full  |
|             | `removeItem(Item item)`                   | Remove existing bagel from basket                                       | Item removed        |
|             |                                           | Remove bagel not in basket                                              | Error: not found    |
|             | `isFull()`                                | Basket is at capacity                                                   | true                |
|             |                                           | Basket has free space                                                   | false               |
|             | `changeCapacity(int newCapacity)`         | Manager changes basket capacity                                         | Updated capacity    |
|             | `getTotalCost()`                          | Basket has items                                                        | Total price         |
|             | `getItemCost(String sku)`                 | Item exists in inventory                                                | Item price          |
|             | `addFilling(Item bagel, Filling filling)` | Filling exists in inventory                                             | Filling added       |
|             |                                           | Filling not in inventory                                                | Error: invalid      |
|             | `getFillingCost(Filling filling)`         | Filling exists in inventory                                             | Filling price       |
|             | `validateItemExists(Item item)`           | Item exists in inventory                                                | true                |
|             |                                           | Item not in inventory                                                   | false               |
| `Inventory` | `hasItem(String sku)`                     | SKU exists                                                              | true                |
|             |                                           | SKU does not exist                                                      | false               |
|             | `getItemPrice(String sku)`                | SKU exists                                                              | price (num)         |
|             |                                           | SKU not found                                                           | Error               |
|             | `getFillingPrice(String sku)`             | SKU exists and is filling                                               | price (num)         |
| `IProducts` | —                                         | Represents bagels, coffees, and fillings with SKU, name, variant, price | —                   |
