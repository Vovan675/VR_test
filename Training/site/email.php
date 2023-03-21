<?php
function SendMail()
{
    $name = $_POST['name'];
    $answer = $_POST['answer'];
    $question = $_POST['question'];
    mail("ccaassaa.vova@yandex.ru", "User $name answered", "Question is: $question\nAnswer is: $answer");
}
?>
