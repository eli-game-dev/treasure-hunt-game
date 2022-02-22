<div dir='rtl' lang='he'>
  
# treasure-hunt-game

משחק מבוסס חידות חברתי המשלב תחרות וחווית משחק בתלת מימיד.
  
המשחק מכוון להיות משחק מרובה משתתפים.
  
השאלות יוגדרו בתחילת המשחק על ידי מנהל המשחק.
 
 השחקנים יפתרו מספר חידות אשר כל חידה תוביל לחידה הבאה\,
 והחידה האחרונה מובילה למטמון.
 
 הראשון שפותר את כל החידות ומגיע למטמון הוא המנצח.
 

  * [רכיבים רשמיים](https://github.com/eli-game-dev/treasure-hunt-game/blob/main/formal-elements.md)

## core game loop
 itch.io: https://eliyahup.itch.io/treasure-hunt-game
 trailer: https://www.youtube.com/watch?v=IIt3AXXro_Q
![Untitled](https://user-images.githubusercontent.com/57856087/142923652-010775e3-cfbc-47c5-9c97-48f89c13a05d.png)

במטלה הזו ממשתי את התהליך העקרי שהשחקן עושה בתלת מימד.
יצרתי שחקן מקפסולה והוספתי לו charater controller ועשיתי שיוכל לזוז גם בעזרת המקשים וגם עם העכבר.
 רכיב המצלמה מחובר לסקריפט של השחקן על מנת שכשאר השחקן יסתובב עם העכבר גם המצלמה וגם השחקן יזוזו.
בנוסף נעלתי את הסמן של העכבר במהלך המשחק.
[KeyboardMover](https://github.com/eli-game-dev/treasure-hunt-game/blob/main/Assets/scripts/KeyboardMover.cs)

הוספתי 2 קוביות שכאשר נוגעים בהם מוצגת לשחקן שאלה עם מספר תשובות שהוא צריך לבחור.
את השאלות עשיתי באמצעון canvas של ספריה מיוחדת שהורדתי מהאינטרנט
כך שכאשר לוחצים על שאלה יש אפקט של לחיצה.

בנוסף כאשר עולים על קוביה מופיע לשחקן שהוא צריך ללחות על מקש E כדי לראות את השאלות כאשר השחקן לוחץ על המקש מופיעה השאלה והעכבר מוצג כדי לענות על השאלות ולא ניתן לסובב את השחקן בזמן הזה על מנת שיהיה נוח לענות על השאלה.
כאשר השחקן יורד מהקוביה השאלה יורדת וניתן להמשיך כרגיך במשחק בדרך לקוביה הבאה.
[interact](https://github.com/eli-game-dev/treasure-hunt-game/blob/main/Assets/scripts/interact.cs)

במטלה זו רק ממשתי את הרעיון הכללי ושמתי את הקוביות מול השחקן בתחילת המשחק. במשחק האמיתי נחביא את הקוביות ולאחר כל תשובה ניתן רמז לקוביה הבאה.

##  תהליך הפתיחה ופיתוח המשחק 
בתחילת המשחק מוצג לשחקן הסברים מה הוא צריך לעשות למשך כ15 שניות בעזרת הסקריפט הבא 
[StartInstruction](https://github.com/eli-game-dev/treasure-hunt-game/blob/main/Assets/scripts/StartInstruction.cs)

הגדרתי אובייקט Game manger שהוא אחראי על הגדרת השאלות על ידי המשתמש (כרגע רק ביוניטי). ניתן להגדיר את מספר השאלות בכל שאלה מגדירים מה השאלה מה ה4 תשובות אפשריות ומה צבע התשובה הנכונה (הוגד ב-Enum).
![Screenshot (27)](https://user-images.githubusercontent.com/57856087/144183224-b36b8005-2daf-41e2-98e2-67419e042b0f.png)

כאשר המשתמש עונה תשובה נכונה קופצת לו הודעה שהוא ענה נכון וכאשר המשתמש עונה תשובה שגויה קופצת לו הודעה שהוא ענה תשובה שגויה והוא קופא במקום למספר שניות .
כאשר המשתמש ענה על כל השאלות הוא הוא למסך שמודיע לו שהוא ניצח.
[GameManger](https://github.com/eli-game-dev/treasure-hunt-game/blob/main/Assets/scripts/GameManger.cs)
  ![Screenshot (23)](https://user-images.githubusercontent.com/57856087/144183349-d8fc17b4-2d45-4cfc-a1f8-190c442f8fb8.png)
![Screenshot (26)](https://user-images.githubusercontent.com/57856087/144183355-0aa7085e-cf07-497a-97b6-0372aef1ec18.png)


כאשר השחקן סיים לענות על שאלה בקוביה מסוימת לא ניתן לחזור לאותה קוביה ב בשביל לענות על שאלה אלא הוא צריך לחפש קוביה אחרת.
ביצעתי את זה באמצעות משתנה סטטי ועוד משתנה בוליאני של האובייקט כדי לכבות כל קוביה בנפרד.
[interact](https://github.com/eli-game-dev/treasure-hunt-game/blob/main/Assets/scripts/interact.cs)

## Multiplayer
הפכתי את המשחק למשחק מרובה משתתפים בעזרת פוטון(נעזרתי במדריך הבסיסי שלהם).

הוספתי כאשר כל שחקן עונה על שאלה מוצג לו על כמה שאלות הוא ענה מתוך כמה.
[Score](https://github.com/eli-game-dev/treasure-hunt-game/blob/main/Assets/scripts/Player/Score.cs)

בנוסף כאשר שחקן עונה על שאלה אז הוא מקבל רמז היכן נמצאת השאלה הבאה. הרמז מוצג לשחקן בפינה העליונה מצד ימין 
[interact](https://github.com/eli-game-dev/treasure-hunt-game/blob/main/Assets/scripts/Cube/interact.cs)

![Screenshot (47)](https://user-images.githubusercontent.com/57856087/147014890-cd78e410-4b85-4a33-be22-5c49f8a4a671.png)


</div>
