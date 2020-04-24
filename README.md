# TrashITBackEnd #
 
## Basket ##

Basket is the class that deals with managing the SmartBins with which TrashIT application can interact.
This class has three different attributes:

1) IdBasket: it is the primary key.
2) Location: it is the place where the SmartBin is located.
3) MacAddress: it is the SmartBin's MAC and it is used to associate the smartphone to the SmartBin.

## ObjectToTrash ##

ObjectToTrash is the class that contains data about different objects that people wish recycle.
Like the previous class it has three attributes:

1) Barcode: it is the primary key; it is used by TrashIT to get info about that barcode from TrashITBackend.
2) Material: it is used by TrashIT to communicate to the SmartBin which is the right basket to open.
3) Description: it is a short description of the object.