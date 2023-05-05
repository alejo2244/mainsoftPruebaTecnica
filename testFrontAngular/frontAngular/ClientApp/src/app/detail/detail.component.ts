import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from '../Models/Book.model';

@Component({
  selector: 'app-detail-component',
  templateUrl: './detail.component.html'
})
export class DetailComponent {
  id: string;
  book: Book;
  constructor(private route: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.id = this.route.snapshot.paramMap.get('id');
    http.get<Book>(baseUrl + 'Books/' + this.id).subscribe(result => {
      this.book = result;
      console.log(result);
    }, error => console.error(error)); }


  ngOnInit(): void {
    // Aquí puedes usar el valor de "id" para cargar los datos del perfil
  }
}
