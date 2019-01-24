import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Article } from './article';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    article: Article = new Article();   // edited article
    articles: Article[];                // articles array
    tableMode: boolean = true;          // table mode

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadArticles();     
    }
    
    loadArticles() {
        this.dataService.getArticles()
            .subscribe((data: Article[]) => this.articles = data);
    }
    
    save() {
        if (this.article.id == null) {
            this.dataService.createArticle(this.article)
                .subscribe((data: Article) => this.articles.push(data));
        } else {
            this.dataService.updateArticle(this.article)
                .subscribe(data => this.loadArticles());
        }
        this.cancel();
    }
    editArticle(p: Article) {
        this.article = p;
    }
    cancel() {
        this.article = new Article();
        this.tableMode = true;
    }
    delete(p: Article) {
        this.dataService.deleteArticle(p.id)
            .subscribe(data => this.loadArticles());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}