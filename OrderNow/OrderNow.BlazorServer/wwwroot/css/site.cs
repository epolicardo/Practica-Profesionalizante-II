@import url('open-iconic/font/css/open-iconic-bootstrap.min.css');

* {
    border: 0px rgb(182, 214, 226) solid;
}

html,
body {
    font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
    /* border: 1px red solid; */
}

h1:focus {
    outline: none;
}

a,
.btn-link {
    color: #0071c1;
}

.btn-primary {
    color: #fff;
    background-color: #1b6ec2;
    border-color: #1861ac;
}

.content {
    padding-top: 1.1rem;
}

.valid.modified:not([type=checkbox]) {
    outline: 1px solid #26b050;
}

.invalid {
    outline: 1px solid red;
}

.validation-message {
    color: red;
}

#blazor-error-ui {
    background: lightyellow;
    bottom: 0;
    box-shadow: 0 -1px 2px rgba(0, 0, 0, 0.2);
    display: none;
    left: 0;
    padding: 0.6rem 1.25rem 0.7rem 1.25rem;
    position: fixed;
    width: 100%;
    z-index: 1000;
}

    #blazor-error-ui .dismiss {
        cursor: pointer;
        position: absolute;
        right: 0.75rem;
        top: 0.5rem;
    }

.blazor-error-boundary {
    background: url(data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNTYiIGhlaWdodD0iNDkiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIG92ZXJmbG93PSJoaWRkZW4iPjxkZWZzPjxjbGlwUGF0aCBpZD0iY2xpcDAiPjxyZWN0IHg9IjIzNSIgeT0iNTEiIHdpZHRoPSI1NiIgaGVpZ2h0PSI0OSIvPjwvY2xpcFBhdGg+PC9kZWZzPjxnIGNsaXAtcGF0aD0idXJsKCNjbGlwMCkiIHRyYW5zZm9ybT0idHJhbnNsYXRlKC0yMzUgLTUxKSI+PHBhdGggZD0iTTI2My41MDYgNTFDMjY0LjcxNyA1MSAyNjUuODEzIDUxLjQ4MzcgMjY2LjYwNiA1Mi4yNjU4TDI2Ny4wNTIgNTIuNzk4NyAyNjcuNTM5IDUzLjYyODMgMjkwLjE4NSA5Mi4xODMxIDI5MC41NDUgOTIuNzk1IDI5MC42NTYgOTIuOTk2QzI5MC44NzcgOTMuNTEzIDI5MSA5NC4wODE1IDI5MSA5NC42NzgyIDI5MSA5Ny4wNjUxIDI4OS4wMzggOTkgMjg2LjYxNyA5OUwyNDAuMzgzIDk5QzIzNy45NjMgOTkgMjM2IDk3LjA2NTEgMjM2IDk0LjY3ODIgMjM2IDk0LjM3OTkgMjM2LjAzMSA5NC4wODg2IDIzNi4wODkgOTMuODA3MkwyMzYuMzM4IDkzLjAxNjIgMjM2Ljg1OCA5Mi4xMzE0IDI1OS40NzMgNTMuNjI5NCAyNTkuOTYxIDUyLjc5ODUgMjYwLjQwNyA1Mi4yNjU4QzI2MS4yIDUxLjQ4MzcgMjYyLjI5NiA1MSAyNjMuNTA2IDUxWk0yNjMuNTg2IDY2LjAxODNDMjYwLjczNyA2Ni4wMTgzIDI1OS4zMTMgNjcuMTI0NSAyNTkuMzEzIDY5LjMzNyAyNTkuMzEzIDY5LjYxMDIgMjU5LjMzMiA2OS44NjA4IDI1OS4zNzEgNzAuMDg4N0wyNjEuNzk1IDg0LjAxNjEgMjY1LjM4IDg0LjAxNjEgMjY3LjgyMSA2OS43NDc1QzI2Ny44NiA2OS43MzA5IDI2Ny44NzkgNjkuNTg3NyAyNjcuODc5IDY5LjMxNzkgMjY3Ljg3OSA2Ny4xMTgyIDI2Ni40NDggNjYuMDE4MyAyNjMuNTg2IDY2LjAxODNaTTI2My41NzYgODYuMDU0N0MyNjEuMDQ5IDg2LjA1NDcgMjU5Ljc4NiA4Ny4zMDA1IDI1OS43ODYgODkuNzkyMSAyNTkuNzg2IDkyLjI4MzcgMjYxLjA0OSA5My41Mjk1IDI2My41NzYgOTMuNTI5NSAyNjYuMTE2IDkzLjUyOTUgMjY3LjM4NyA5Mi4yODM3IDI2Ny4zODcgODkuNzkyMSAyNjcuMzg3IDg3LjMwMDUgMjY2LjExNiA4Ni4wNTQ3IDI2My41NzYgODYuMDU0N1oiIGZpbGw9IiNGRkU1MDAiIGZpbGwtcnVsZT0iZXZlbm9kZCIvPjwvZz48L3N2Zz4=) no-repeat 1rem/1.8rem, #b32121;
    padding: 1rem 1rem 1rem 3.7rem;
    color: white;
}

    .blazor-error-boundary::after {
        content: "An error has occurred."
    }

.login-card-container {
    display: flex;
    margin-left: 50vh;
    margin-top: 10vh;
    box-shadow: 10px 10px 20px 4px #e2d6cf;
    height: 450px;
    width: 850px;
}

.login-card {
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 10px 10px 10px 10px;
    border-radius: 10px;
}

.login-card-left {
    width: 400px;
}

    .login-card-left img {
        padding: 20px;
        width: 350px;
        border-radius: 40px;
    }

.login-card-right {
    padding: 10px 10px 10px 10px;
}

    .login-card-right button {
        margin-left: 40px;
    }

    .login-card-right a {
        text-decoration: none;
        color: #b32121;
        margin-left: 50px;
    }

.login-card-header {
    margin-bottom: 40px;
    text-align: center;
}

.input-data {
    min-width: 350px;
    margin: 0px 0px 10px 0px;
}

.flex-container {
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
}

.metrics-card {
    height: 200px;
    max-width: 450px;
    min-width: 400px;
    box-shadow: 10px 10px 20px 4px #e2d6cf;
}

    .metrics-card .metrics-title {
        color: red;
        font-style: italic;
        font-size: 20px;
        align-items: flex-start;
        padding: 10px;
    }

.item1 {
    grid-area: header;
}

.item2 {
    grid-area: main;
}

.item3 {
    grid-area: der;
}

.item4 {
    grid-area: footer;
}

.container {
    display: grid;
    grid-template-columns: 4fr 2.5fr;
    grid-template-rows: 0.3fr 2.4fr 0.3fr;
    gap: 0px 0px;
}

.Header {
    grid-area: 1 / 1 / 2 / 3;
}

.Main {
    grid-area: 2 / 1 / 4 / 2;
}

.Products {
    grid-area: 2 / 2 / 3 / 3;
}

.Footer {
    grid-area: 3 / 1 / 4 / 3;
}

#last-connection-text {
    color: gray;
    font-family: system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
    font-size: 12px;
}

#customer-name {
    font-size: 20px;
    font-family: Arial, Helvetica, sans-serif;
    font-weight: bold;
}

#profile-img {
    width: 100px;
    height: 100px;
    border-radius: 50%;
}

#fav-title {
    background-color: #ca6b34;
    align-items: center;
}