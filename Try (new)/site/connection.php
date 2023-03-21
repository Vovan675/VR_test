<?php
    $connection = new mysqli("localhost", "cz94391_answers", "Sasata123", "cz94391_answers");
    if ($connection->errno)
    {
        die($connection->error);
    }
?>