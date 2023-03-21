<?php
    require ("email.php");
    require ("connection.php");

    $name = $_POST['name'];
    $answer = $_POST['answer'];
    $question = $_POST['question'];
	echo ("1 $name");
	echo ("2 $answer");
	echo ("3 $question");
    $con->query("INSERT INTO answers (name, answer, question) VALUES ('$name', '$answer', '$question')");
    $con->close();
    SendMail();
?>