# nasa-demo

This is a sample application for downloading NASA Mars Rover images.

## Usage

Start the web application and upload a text file on the form.

The text file should contain dates, with one date appearing per line.

The dates can be in any of the following formats:

- `MM/dd/yy`
- `MMMM d, yyyy`
- `MMM-dd-yyyy`
- `MMMM dd, yyyy`

You can use the sample file `sample-dates.txt` to test.

It will download images to the `wwwroot\NASAImages` folder, as well as display the images on the page.

## Running in Docker (Windows)

To run the app in Docker:
1. Navigate to the `src` directory.
2. Run `docker build -t nasademo.web .`
3. Run `docker run -d -p 8080:80 --name myapp nasademo.web`
4. Browse the app at `http://localhost:8080/`

## About

Primary technology stack:
- .NET Core 3.1.403
- AlpineJS 2.7.3
- TailwindCSS 1.8.10

Architecture and programming style:
- Vertical slices rather than horizontal layers
- Declarative rather than imperative
- Opt-in to features rather than using entire frameworks

Parts:
- Web Project
- Core Project with Test
- NASA Project with Test