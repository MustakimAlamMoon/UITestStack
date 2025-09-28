Feature: Steam

Scenario: Verify Privacy Policy
    Given Main page is open
    When I scroll and open Privacy Policy
    Then Privacy Policy page is opened in new tab
    And Switch language elements list displayed
    And Supported languages <Languages>
    And Policy revision signed in the current year

    Examples:
      | Languages               |
      | English                 |
      | Spanish - Spain         |
      | French                  |
      | German                  |
      | Italian                 |
      | Russian                 |
      | Japanese                |
      | Portuguese - Portugal   |
      | Portuguese - Brazil     |



Scenario: Browse and Filter Products
    Given Main page is open

    When I click on 'Top Sellers' option in the "BROWSE CATEGORIES" section of the left menu
    Then the page with Top Sellers products is open
    
    When I move the handle of the slider in the 'Narrow by Price' section to the "Under $10.00" position
    Then the price range under the slider shows the text "Under $10.00"

    When I select the following filters in the right menu
      | Narrow by tag   | Narrow by OS    |
      | Puzzle          | SteamOS + Linux |
      | 2D              |                 |
      | Fantasy         |                 |

    Then all 4 checkboxes are checked
    And the number of results matching the search equals the number of games in the games list

    When I get the first game's name, release date, and price from the list
    And I click on the first game in the list
    Then the page with the game's description is opened
    And the game's name, release date, and price are equal to the ones from previous step