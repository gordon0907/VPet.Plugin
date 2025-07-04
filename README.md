# VPet.Plugin

這是一個用於 [LorisYounger/VPet](https://github.com/LorisYounger/VPet)
虛擬桌寵模擬器的模組集合，參考自 [LorisYounger/VPet.Plugin.Demo](https://github.com/LorisYounger/VPet.Plugin.Demo)。

## 📦 已包含模組

| 模組名稱                 | 說明                          |
|----------------------|-----------------------------|
| VPet.Plugin.AutoWork | 讓桌寵在閒置時自動重複最近一次的工作（包括學習與玩耍） |

## ⚙️ 安裝指南

1. 前往 [Releases](../../releases) 頁面下載所需模組（此處以 AutoWork 為例）。
2. 解壓縮，並保留模組最外層的資料夾。
3. 將模組資料夾複製到 VPet 模組資料夾中。

   **找到模組資料夾的方法：**
    1. 右鍵點選桌寵
    2. 「系統」→「設定選單」→「模組管理」
    3. 選擇「Core」，點擊「所在資料夾」
    4. 進入該資料夾的上一層即可看到模組資料夾

4. 重新啟動 VPet。
5. 再次進入「模組管理」頁面，選中新加入的模組，點擊「啟用本模組」，並按照指示重新啟動遊戲。
6. 如果 VPet 顯示警告「模組包含程式碼外掛程式」，請到「模組管理」頁面點擊「啟用程式碼外掛程式」，再重新啟動遊戲。
7. 完成安裝。

## ❌ 解除安裝指南

1. 先到「模組管理」頁面停用該模組。
2. 前往 VPet 模組資料夾（同安裝指南第 3 項）。
3. 刪除欲移除的模組資料夾。
4. 若該模組被判定爲「包含程式碼外掛程式」（見安裝指南第 6 項），且你希望徹底移除，請依以下步驟修改設定：
    1. 打開 `Setting.lps`（可透過 Steam VPet 頁面的「瀏覽本機檔案」找到）。
    2. 以 AutoWork 為例，刪除 `passmod:|autowork:|`；若 `passmod:|` 有其他項目，只刪除 `autowork:|` 即可。
    3. 刪除 `msgmod:|AutoWork#True:|`；若 `msgmod:|` 有其他項目，只刪除 `AutoWork#True:|` 即可。
    4. 注意：`Setting.lps` 不需要在最尾保留空白行。

5. 重新啟動 VPet，模組已被徹底移除。
