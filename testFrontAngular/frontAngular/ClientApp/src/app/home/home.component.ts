import { HttpClient } from '@angular/common/http';
import { Component, Inject, TemplateRef } from '@angular/core';
import { Book } from '../Models/Book.model';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public books: Book[];
  public booksOriginal: Book[];
  selectedItem: Book;
  searchControlTitle = new FormControl('');

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Book[]>(baseUrl + 'Books').subscribe(result => {
      this.books = result;
      this.booksOriginal = result;
      console.log(result);
    }, error => console.error(error));
    this.searchControlTitle.valueChanges.subscribe((value) => {
      this.books = value == "" ? this.booksOriginal : this.books.filter((item) =>
        item.title.toLowerCase().includes(value.toLowerCase())
      );
    });
  }

  openModal(book: Book, template: TemplateRef<any>) {
    this.selectedItem = book;
  }
}


