# iA Coding Challenge
By Adrian Salazar
![image](https://user-images.githubusercontent.com/13540588/221673413-af83d543-f048-4ffd-96c9-28fb406ef17d.png)

## Introduction
This program is designed to accept a location as a pair of coordinates adjusted by the input fields below. After pressing the button, the program will return a list of the	three closest central fill facilities from a random seed, along with the cheapest medication price for each	central fill.

It was implemented using Blazor Server App on C# in order to provide a more 'realistic' look at how this program would be used on a web application or website. The Facility List component should have the ability to dynamically re-render upon clicking the button at the main body. 

### Assumptions
The following are some assumptions made:

- All Facilities and Medications each have unique key values
- Edge cases for input coordinates exceeding are handled in the front end
- FacilityRepository is set to retrieve both 'as-is' Facility entries and top 3 items with an ordered list of medications
- Some data constraints for each Model are handled with data annotations like [Range]
- Cases where Manhattan Distance is the same between two central fills, then the order will be determined by the ID
this could be modified to be based on Medication instead


### Possible Changes
Because this is a program operating with a in-memory database, I would modify the program
to include an actual connection string to a database to simulate a more realistic scenario
since in-memory would not be something feasible or secure to work with.
Another major change would be in the way the repository pattern is used - at the moment,
I am injecting `FacilityRepository`, Ideally I would take advantage of
the Controller I created and use a Service pattern instead to keep the fetching data better structured
and be able to take the advantage of a proper API call to avoid overwhelming the DB with direct calls.

For cases where the code would be used on a higher traffic, I would optimize ways to access the
data by creating stored procedures inside the database, setup more security procedures for retrieving
data. And as mentioned before, using a proper API endpoint would ease network traffic and allow more flexibility
to the request (what if we want to look at all medications? )


### Caveats

- Random seed generation wasn't added due to time limitations
- There are no 'duplicate' Medications (eg. if two instances of MedicationId = 2 exist, DbContext will immediately throw an error).
Did not have time to setup a stronger relational database for a one to many relation
- In-memory database is a JSON file instead of a proper DB
- Collision detection isn't 100% implemented, when calling methods from the FacilityRepository
will throw an error if things from data annotations are violated but not all cases are handled
- Did not contain the Facility List as its own Razor component
- Missed on creating a test case project due to time


## Setup
- Open the `.sln` file using Visual Studio 2019 or above
- Build and Run the site/server with the 'build' button, no other requirements needed
- To use a different data set, I recommend https://json-generator.com/ and use the following snippet to generate a random amount of facilities and medications on each:
```
[
  '{{repeat(7, 10)}}',
  {
    facilityId: '{{integer(1, 999)}}',
    facilityCoordinateX: '{{integer(-10, 10)}}',
	facilityCoordinateY: '{{integer(-10, 10)}}',
    medications: [
      '{{repeat(1,10)}}',
      {
        medicationId: '{{index()}}{{integer(0, 10)}}',
        medicationPrice: '{{floating(0.01, 999)}}'
      }
    ]
  }
]

```


## Troubleshooting
- If the program does not open for you, ensure the following NuGet packages are included:
-- `Microsoft.MicrosoftEntityCore`
-- `Microsoft.MicrosoftEntityCore.InMemory`
-- `Newtonsoft.Json`
