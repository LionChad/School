# 目的
這是LionChad測試撰寫課程API之用
https://github.com/LionChad/School
# 課程API

此程式內容為:這是一個處理課程的API，使用了CRUD與Restful技術。

## 功能特點

- 支援功能，可CRUD課程清單、CRD必修課程清單、CRD課程時間清單。

## 程式碼結構

`CourseDataModel` 類別代表課程資訊，包含以下屬性：

- `CourseID`：課程 ID
- `CourseTitle`：課程標題
- `CourseIntroduction`：課程介紹
- `ProfessorName`：教授姓名
- `Week`：星期幾
- `Time`：課程時間，格式為 HHmm-HHmm
- `RequiredSubjects`：必修科目

## 如何使用

"api/Course"
依據Restful技術，根據需求使用

## 需求

- .NET Core 3.1 或更高版本。

## 安裝與執行

1. 下載或克隆此專案到你的本地環境。
2. 使用 Visual Studio 或命令列工具編譯和執行。

## 貢獻


## 授權

