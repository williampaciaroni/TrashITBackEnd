# TrashITBackEnd #

## TECHNOLGIES ##

#### ASP.NET Core ####

#### C# ####

#### Azure ####

#### SQLServer ####

## CLASSES  ##
 
#### Basket ####

Basket is the class that deals with managing the SmartBins with which TrashIT application can interact.
This class has three different attributes:

1) IdBasket: it is the primary key.
2) Location: it is the place where the SmartBin is located.
3) MacAddress: it is the SmartBin's MAC and it is used to associate the smartphone to the SmartBin.

#### ObjectToTrash ####

ObjectToTrash is the class that contains data about different objects that people wish recycle.
Like the previous class it has three attributes:

1) Barcode: it is the primary key; it is used by TrashIT to get info about that barcode from TrashITBackEnd.
2) Material: it is used by TrashIT to communicate to the SmartBin which is the right basket to open.
3) Description: it is a short description of the object.

## API ##

#### POST ../api/basket/add ####

It is the endpoint used to add a new SmartBin.
It accepts only POST requests and they must have a raw body(Content-Type:application/json) which contains:

1) MacAddress
2) Location


#### GET ../api/basket/getByLocation ####

It is the endpoint used to get the MacAddress of the SmartBin placed in the sent location.
It accepts only GET requests and they must have a param "Location".
It returns a JSON object containing the MAC.


#### POST ../api/object/add ####

It is the endpoint used to add a new object.
It accepts only POST requests and they must have a raw body(Content-Type:application/json) which contains:

1) Description
2) Material
3) Barcode


#### GET ../api/object/getByBarcode ####

It is the endpoint used to get the Material of the Object that the user wishes recycle.
It accepts only GET requests and they must have a param "Barcode".
It returns a JSON object containing the Material.