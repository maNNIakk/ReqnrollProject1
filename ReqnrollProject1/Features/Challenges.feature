Feature: Challenges

Scenario: UserType Challenge
Given I have the following users
| UserName | UserType      |
| Alice    | admin         |
| Bob      | user          |
| John     | guest         |
| Sally    | user          |
| Magnus   | administrator |
|          | manager       |
|          | cybersecurity |
Then the internal user type for users is 
| UserName | UserType |
| Alice    | Admin    |
| Bob      | User     |
| John     | Guest    |
| Sally    | User     |
| Magnus   | Admin    |
|          | Unknown  |
|          | Unknown  |

Scenario: Geolocation Challenge
Given I have the following stores
| StoreName | GeoLocation |
| US-Store  | 3.14,5.43   |
| UK-Store  | 3.29,4.56   |
| DE-Store  | 4.12,6.78   |
Then the correspondent GeoLocation from stores are
| StoreName | Latitude | Longitude |
| US-Store  | 3.14     | 5.43      |
| UK-Store  | 3.29     | 4.56      |
| DE-Store  | 4.12     | 6.78      |
