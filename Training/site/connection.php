<?php
    $con = new mysqli("localhost", "cz94391_answers", "Sasata123", "cz94391_answers");
    if ($con->connect_errno)
    {
        die ($con->connect_error);
    }
?>