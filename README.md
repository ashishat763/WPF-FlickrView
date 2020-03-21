# FlickrView

## Technical Details
1. Windows Application(.exe) utilizing WPF
2. FlickrViewTest is the unit test project. Uses MStest and Rhino Mocks.
3. AppVeyor(.yml) is used as the CI/CD tool.
4. The binary(FlickrView.exe) is pushed to an S3 instance after unit tests are executed.
5. Clone the repo in your local and build the solution. Feel free to use the code as you deem fit. :)

## Functional Details
1. Launch the app(FlickrView.exe) after build.
2. Enter your search value(like nature, snow etc.) and Flickr from the dropdown. Click Search button.
3. You can multiple search value separated by space.
4. At the moment, you can a max of 20 results at a time.


