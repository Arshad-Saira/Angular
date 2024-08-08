import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { BookService } from '../book.service';
import { HttpClientModule } from '@angular/common/http';  // Import HttpClientModule

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  books: any[] = [];
  rowsStart = 0;
  rowsEnd = 10;

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(): void {
    this.bookService.getBooks().subscribe(data => {
      this.books = data.slice(this.rowsStart, this.rowsEnd);
    });
  }

  loadMore(): void {
    this.rowsStart = this.rowsEnd;
    this.rowsEnd += 10;
    this.bookService.getBooks().subscribe(data => {
      this.books = data.slice(this.rowsStart, this.rowsEnd);
    });
  }
}
