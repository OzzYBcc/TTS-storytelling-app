# TTS Storytelling App

## Overview
This Text-to-Speech (TTS) Storytelling App is a C# desktop application designed to deliver an engaging storytelling experience using Microsoft Windows TTS voices. It includes a collection of built-in stories, retrieves additional stories via an API, and supports dynamic playback controls such as play, pause, resume, volume adjustment, and speech speed modification. Stories are categorized (e.g., preschool, fantasy) and stored in a SQLite database for efficient management. The app showcases robust GUI development, API integration, and database handling.

## Technologies
- **Language**: C# (.NET Framework)
- **TTS Engine**: Microsoft Windows Text-to-Speech
- **Database**: SQLite
- **API Interaction**: HttpClient for retrieving stories
- **JSON Parsing**: Newtonsoft.Json (Json.NET)
- **GUI**: Windows Forms or WPF (depending on implementation)

## Features
- Interactive storytelling with Microsoft Windows TTS voices, supporting customizable speech parameters (volume, speed).
- Built-in collection of at least 5 stories, categorized by type (e.g., preschool, fantasy).
- Retrieval of unique stories from an external API using HttpClient and JSON parsing.
- Playback controls: play, pause, resume, louder/softer volume, and faster/slower speech.
- Persistent storage of stories in a SQLite database for efficient categorization and retrieval.
- User-friendly GUI for seamless story selection and playback.

## Installation
1. Clone the repository:
   ```
   git clone https://github.com/OzzYBcc/TTS-storytelling-app.git
   ```
2. Navigate to the project directory:
   ```
   cd TTS-storytelling-app
   ```
3. Open the solution file (`.sln`) in Visual Studio.
4. Ensure the required NuGet packages are installed (e.g., `Newtonsoft.Json` for JSON parsing).
5. Set up the SQLite database by running the `setup.sql` script (located in the `/db` directory) to initialize the story database.
6. Build and run the project in Visual Studio:
   ```
   dotnet build
   dotnet run
   ```

## Usage
- **Story Selection**: Choose from built-in stories or fetch new ones via the API.
- **Playback Controls**: Use buttons to play, pause, resume, adjust volume, or modify speech speed.
- **Story Categories**: Browse stories by category (e.g., preschool, fantasy) in the GUI.
- **Example Code (TTS Playback)**:
  ```csharp
  using System.Speech.Synthesis;

  public class StoryPlayer {
      private SpeechSynthesizer synthesizer = new SpeechSynthesizer();

      public void PlayStory(string text) {
          synthesizer.Volume = 100; // 0-100
          synthesizer.Rate = 0;    // -10 to 10
          synthesizer.SpeakAsync(text);
      }

      public void Pause() {
          synthesizer.Pause();
      }

      public void Resume() {
          synthesizer.Resume();
      }
  }
  ```
- **Example API Call**:
  ```csharp
  using System.Net.Http;
  using Newtonsoft.Json;

  public async Task<string> FetchStoryAsync(string apiUrl) {
      using (HttpClient client = new HttpClient()) {
          var response = await client.GetStringAsync(apiUrl);
          var storyData = JsonConvert.DeserializeObject<dynamic>(response);
          return storyData.storyText;
      }
  }
  ```

## Contributing
Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Open a pull request.

Potential improvements include adding support for multiple languages, enhancing the GUI with modern styling, or integrating additional story APIs.

## License
MIT License