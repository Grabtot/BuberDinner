# Domain Models 

## Menu

```cs
class Menu
{
  Menu Create();
  void AddDinner(Dinner dinner);
  void Remove(Dinner dinner);
  void UndateSection (MenuSetion section);
}

```

```json
{
"id": "00000000-0000-0000-0000000000",
"name": "SuperDinner",
"description": "A menu with yummy food",
"avarageRating": 4.5
"sections": [
 { 
  "id": "00000000-0000-0000-0000000000",
  "name": "Appetisers",
  "description": "Starters",
  "items": [
    {
      "id": "00000000-0000-0000-0000000000",
      "name": "Fried Pickles",
      "description": "Deep fried pickles",
      "price": 5.99
    }
  ]
 }
],
"createdDateTime": "2020-01-01T00:00:00.0000000Z",
"updatedDateTime":"2020-01-01T00:00:00.0000000Z",
"hostId": "00000000-0000-0000-0000000000",
"dinners": [
"00000000-0000-0000-0000000000",
"00000000-0000-0000-0000000000"
],
"menuReviev": "00000000-0000-0000-0000000000"
}
```