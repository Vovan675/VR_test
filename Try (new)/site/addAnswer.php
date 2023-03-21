<?php
    require("connection.php");
    $nickname = $_POST["nickname"];
    $question = $_POST["question"];
    $answer = $_POST["answer"];
    $connection->query("INSERT INTO testAnswers (nickname, question, answer) VALUES ('$nickname', '$question', '$answer')");
    $connection->close();
?>