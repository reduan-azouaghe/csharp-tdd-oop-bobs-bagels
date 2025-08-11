| Class           | Method                                        | Scenario                                                             | Output / Action    |
| --------------- | --------------------------------------------- | -------------------------------------------------------------------- | ------------------ |
| `Basket`        | `addProduct(IProduct product)`                | Add product when basket has space                                    | Product added      |
|                 |                                               | Add product when basket is full                                      | Error: basket full |
|                 | `removeProduct(IProduct product)`             | Remove product that exists in basket                                 | Product removed    |
|                 |                                               | Remove product not in basket                                         | Error: not found   |
|                 | `isFull()`                                    | Basket is at capacity                                                | `true`             |
|                 |                                               | Basket has free space                                                | `false`            |
|                 | `changeCapacity(int newCapacity)`             | Manager changes basket capacity                                      | Capacity updated   |
|                 | `getTotalCost()`                              | Basket has products                                                  | Total price        |
|                 | `getProductCost(String sku)`                  | Product exists in inventory                                          | Product price      |
|                 | `addFilling(IProduct bagel, Filling filling)` | Filling exists in inventory                                          | Filling added      |
|                 |                                               | Filling not in inventory                                             | Error: invalid     |
|                 | `getFillingCost(Filling filling)`             | Filling exists in inventory                                          | Filling price      |
|                 | `validateProductExists(IProduct product)`     | Product exists in inventory                                          | `true`             |
|                 |                                               | Product not in inventory                                             | `false`            |
| `Inventory`     | `hasProduct(String sku)`                      | SKU exists                                                           | `true`             |
|                 |                                               | SKU does not exist                                                   | `false`            |
|                 | `getProductPrice(String sku)`                 | SKU exists                                                           | Price (num)        |
|                 |                                               | SKU not found                                                        | Error              |
|                 | `getFillingPrice(String sku)`                 | SKU exists and is filling                                            | Price (num)        |
| `IProducts`     | —                                             | Represents bagels, coffees, and fillings (SKU, name, variant, price) | —                  |
