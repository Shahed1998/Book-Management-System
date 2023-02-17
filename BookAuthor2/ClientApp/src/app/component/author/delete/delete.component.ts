import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { Router } from '@angular/router';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

  authorId!: Number
  author: any

  constructor(private activatedRoute : ActivatedRoute, private apiservice: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((param)=>{
      !Number(param.get('id')) ? this.router.navigate(['/authors']) : this.authorId = Number(param.get('id'));
    })

    this.deleteAuthor(this.authorId);
  }

  public deleteAuthor(id: Number)
  {
    this.apiservice.deleteAuthor(id).subscribe(response => {
      this.router.navigate(['/authors'])
    }, error => {
      this.router.navigate(['/authors'])
    })
  }
}
