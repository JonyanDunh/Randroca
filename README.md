
<p align="center">
  <a href="https://github.com/jonyandunh/Randroca">
    <img src="https://github.com/JonyanDunh/Randroca/blob/master/resource/swopen.png?raw=true" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Randroca</h3>

  <p align="center">
    A software that randomly selects users to facilitate the selection of many scenes, such as students in the classroom, the luckiest staff in a company, and the luckiest viewer in tv shows.
    <br/>
    <br/>
  </p>


![Downloads](https://img.shields.io/github/downloads/jonyandunh/Randroca/total) ![Contributors](https://img.shields.io/github/contributors/jonyandunh/Randroca?color=dark-green) ![Forks](https://img.shields.io/github/forks/jonyandunh/Randroca?style=social) ![Stargazers](https://img.shields.io/github/stars/jonyandunh/Randroca?style=social) ![Issues](https://img.shields.io/github/issues/jonyandunh/Randroca) ![License](https://img.shields.io/github/license/jonyandunh/Randroca) 

## Table Of Contents

* [About the Project](#about-the-project)
* [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Contributing](#contributing)
* [License](#license)
* [Authors](#authors)
* [Acknowledgements](#acknowledgements)

## About The Project

#### **Preview:**

**Main interface**

![Screen Shot](https://raw.githubusercontent.com/JonyanDunh/Randroca/master/image-20200727133405856.png)

**Hover boll(main interface is hidden)**

![image-20200727133244018](https://raw.githubusercontent.com/JonyanDunh/Randroca/master/image-20200727133236642.png)

**Hover boll(main interface is visible)**

![image-20200727133350900](https://raw.githubusercontent.com/JonyanDunh/Randroca/master/image-20200727133350900.png)

**About page**

![image-20200727133430138](https://raw.githubusercontent.com/JonyanDunh/Randroca/master/image-20200727133430138.png)

#### Why did I develop the software?

I developed the software when I was a high school student🏫. 
Every time I saw my teacher need to choose a student to answer her question, she will take out a table which contains all students' names in my class and select a student from it📃. 
I thought it was so inconvenient🤔, and I decide to make software to solve the problem, so I developed the software named Randroca.

## Built With

The software mainly uses  WPF of the .NET Framework to build because it is so convenient to beautify on Windows system, and it can save the development time.

## Getting Started

`MainWindow.xaml` is the main interface;
`Float.xaml` is the hover ball;
`About.xaml` is the about-page

### Prerequisites

If you wanna change the user list, you need to modify the function called `Roll_call()` in `MainWindow.xaml.cs`. Inside the function, you will see a string array called `name`, insert some user names that you want to appear on the software's selection. At the same time, you need to add some photos to `resource/face`. They need PNG format, and their file name are the same as the user that you insert into the `name` array.

### Installation

`git clone https://github.com/JonyanDunh/Randroca.git`
`cd Randroca`

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.
* If you have suggestions for adding or removing projects, feel free to [open an issue](https://github.com/jonyandunh/Randroca/issues/new) to discuss it, or directly create a pull request after you edit the *README.md* file with the necessary changes.
* Please make sure you check your spelling and grammar.
* Create individual PR for each suggestion.
* Please also read through the [Code Of Conduct](https://github.com/jonyandunh/Randroca/blob/main/CODE_OF_CONDUCT.md) before posting your first idea as well.

## License

Randroca is now open-source, secure, free, and trustworthy under the GNU GPL 3.0 license for mutual progress and transparency to users. This program is distributed under the terms of the GNU General Public License. If necessary, please also comply with the open-source license GNU General Public License

## Authors

* **Jonyan Dunh** - *A Full Stack developer from China I’m currently learning the field of deep learning, such as GAN, DRL, NPL and CV...* - [Jonyan Dunh](https://twitter.com/JonyanDunh) - *Whole of the project*

## Acknowledgements

* [WPF](https://github.com/dotnet/wpf)
