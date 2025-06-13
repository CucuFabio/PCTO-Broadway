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
