using System;
using System.Collections.Generic;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Snowfall");
Raylib.SetTargetFPS(60);

Random generator = new Random();
List<Rectangle> snowflakes = new List<Rectangle>();
List<float> snowSpeed = new List<float>();

for (int i = 0; i < 2000; i++)
{
  int x = generator.Next(Raylib.GetScreenWidth());
  int y = generator.Next(Raylib.GetScreenHeight());

  int size = generator.Next(2, 7);
  float speed = (float) (generator.NextDouble() + 0.5);
  snowSpeed.Add(speed);
  snowflakes.Add(new Rectangle(x, y, size, size));
}

while (!Raylib.WindowShouldClose())
{
  Raylib.BeginDrawing();
  Raylib.ClearBackground(Color.SKYBLUE);

  for (int i = 0; i < snowflakes.Count; i++)
  {
    Rectangle flake = snowflakes[i];
    flake.y += snowSpeed[i];
    if (flake.y > 600)
    {
      flake.y = -10;
    }
    snowflakes[i] = flake;

    Raylib.DrawRectangleRec(snowflakes[i], Color.WHITE);
  }

  Raylib.EndDrawing();
}