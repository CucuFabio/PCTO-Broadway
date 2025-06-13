# COMMIT: add .gitignore and README.md
## Understanding the Project

You're off to a great start. This project uses **Vite**, which is a modern build tool for web development. Let’s walk through what that means and what you should keep in mind as you go.

### What is Vite?

Vite helps prepare your code for the browser by doing a few important things:

* It bundles your `.js` and `.css` files together.
* It processes and includes other assets like images (use modern formats like `.webp` or `.avif` when possible — they’re faster and smaller than `.jpg` or `.png`).
* When you run `npm run build`, Vite creates a `dist/` folder. This folder contains the final version of your website — the version you can deploy, for example, to GitHub Pages.

To see what you’ve built, run the build command and open `dist/index.html` in a browser. That’s your project, ready to go.

---

### About `.gitignore`

I noticed your project didn’t include a `.gitignore` file. This is something you should always have in any project using Git. Here’s why:

#### Why it matters

Without a `.gitignore` file, Git will try to track everything in your project — including files that don’t belong in version control. For example:

* The `node_modules/` folder is huge and generated automatically. You never want to commit that.
* `.env` files (used to store things like secret keys or tokens) should always stay private.
* Build outputs like `dist/` aren’t your source code — they can be re-generated.

In your case, Git showed over 390 changes — mostly things that should have been ignored.

#### What you should do

Create a file called `.gitignore` in the root of your project, and add at least the following:

```txt
node_modules/
dist/
.env
```

This will prevent Git from tracking files that don’t belong in your repository.

---

### A few tips going forward

* After you build, open `dist/index.html` in your browser to see what Vite produced.
* Before pushing to GitHub, always check what files you're committing.
* Use `.gitignore` in every project — it keeps things clean and avoids big mistakes, like accidentally sharing secrets.

Commit Often and Clearly

One important habit to build early is to make frequent, small commits. These are called atomic commits — each commit should do one clear thing and have a meaningful message explaining what changed.

For example, in this README, I’m focusing on explaining how the project works and writing a commit message that’s easy for you (and others) to understand later.

Why does this matter?

    It makes it easier to track your progress.

    If something breaks, you can find where and why quickly.

    Others (or future you) can understand your work without confusion.

A good commit message should answer: What did I change? Why did I change it?

Try to keep your commits small and focused — it’ll save you headaches down the road.

Here's a cleaned-up and properly formatted version of your README using `.md` (Markdown) syntax. I've preserved your content but structured it for clarity, readability, and good Markdown practices:

---


# COMMIT: Basic hygiene to remove unused files

Before writing new code, it's good to clean up anything you're not using. This helps keep your project tidy and easier to understand.

In this commit, I removed two files:

* `counter.js`
* `javascript.svg`

These weren’t being used in the project, so they were safe to delete. A clean codebase helps avoid confusion later.

---

## How to Start a New HTML File

In your editor, you can type `!` and then hit <kbd>Tab</kbd> or <kbd>Enter</kbd> to generate a basic HTML template. It gives you something like this:

```html
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>Document</title>
</head>
<body>

</body>
</html>
```

Now you're ready to add scripts or content.

---

## Where to Place `<script src="...">`

📚 [Docs – W3Schools: Where to Place Scripts](https://www.w3schools.com/js/js_whereto.asp)

In your original example, the script was placed **outside the `<body>`**:

```html
<script src="src/main.js"></script>
```

This is technically okay, but **it's better** to put the script at the **end of the `<body>`**, like this:

```html
<body>
  <script src="src/main.js"></script>
</body>
```

### Why?

If you load scripts in the `<head>`, they might run **before** the page finishes loading, which can cause bugs.
Placing them at the end of `<body>` ensures the page content is fully loaded first.

---

## Use `type="module"`

To work with modern JavaScript modules:

```html
<script type="module" src="src/main.js"></script>
```

### Notes:

* If you've set `"type": "module"` in your `package.json`, the `type="module"` attribute is optional.
* To make it **explicit** to other developers that a file is a module, you can also use the `.mjs` extension.
* ES modules let you use `import` and `export` syntax.

---

## Modular Code: Your Own Scripts

Instead of putting all your logic in `main.js`, it's a good idea to split features into their own files.

### Example

**`src/counter.js`**

```js
export function incrementCounter() {
  console.log('Counter increased!');
}
```

**`src/main.js`**

```js
import { incrementCounter } from './counter.js';

incrementCounter();
```

📖 [MDN: JavaScript Modules](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Modules)

---

Certainly! Here's your updated section, properly formatted in Markdown with clean structure and consistent language:

---

## ✅ Try It Yourself

As a next step:

1. Export the functions and constants you've created in `main.js`.
2. Move related logic into separate files. It's good practice to create **many small files** — organize them by purpose or feature.
3. Import those modules back into `main.js`.
4. Run your project in the browser.

💡 **To check if it's working:**

* Open your browser’s developer tools.
* Go to the **Console** tab (`Right-click → Inspect → Console`).
* Look for logs or errors.

---
