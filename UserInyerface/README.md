# UserInyerface Automated Testing with NUnit, Aquality, SpecFlow & Alure

## Overview
This repository contains an automated test suite for [UserInyerface](https://userinyerface.com/), a UI challenge designed to frustrate users. The tests are implemented using **NUnit, Selenium, Aquality Selenium, SpecFlow, BDD, InputSimulator, AutoIT, Allure**, and **Page Object Model (POM)** to ensure robust and maintainable test automation.

## Features
- **BDD-Driven Testing:** Uses Gherkin syntax and SpecFlow for structured test cases.
- **Selenium WebDriver:** Automates browser interactions.
- **Aquality Selenium:** Enhances test stability and parallel execution.
- **InputSimulator & AutoIT:** Handles tricky UI elements and interactions.
- **Allure:** Provides detailed test execution reports.
- **Page Object Model (POM):** Implements a structured approach for maintainability.

## Setup Instructions

### Prerequisites
Ensure you have the following installed:
- .NET SDK 6.0
- Visual Studio 2022
- SpecFlow for Visual Studio (Extension)
- Allure CLI

### Technologies
Project is created with:
- NUnit 4.3.2
- Selenium WebDriver 4.27.0
- Aquality Selenium 4.22.1
- AutoIT / InputSimulator 1.0.4
- SpecFlow 3.9.74
- Allure 2.12.1

### Installation
Clone this repository:
```sh
git clone https://github.com/MustakimAlamMoon/UserInyerface.git
cd UserInyerface
```

### Restore dependencies:
```sh
dotnet restore
```

### Running Tests:
To execute the test suite, use:
```sh
dotnet test
```

### Generate Allure report:

```sh
allure serve allure-results
```

## Test Scenarios
The following test scenarios are automated:
- **Card Data Checking:** Validates form interactions across multiple steps.
- **Hide Help Form:** Ensures UI elements behave correctly when toggled.
- **Accept Cookies:** Confirms cookie acceptance functionality.
- **Validate Timer:** Verifies countdown timer behavior.

## Reporting
All test results are captured using Allure Report. Run the tests and serve the reports using:
allure serve allure-results

## License
This project is licensed under the **MIT License.**

---

Just copy and paste it into your repository, and you're good to go! If you ever need modifications or enhancements, let me know. 🚀