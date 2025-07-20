import { Component, OnInit } from '@angular/core';
import { FuncionariosService } from '../../services/funcionarios';
import { Funcionario } from '../../models/funcionario.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-principal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './principal.html',
  styleUrls: ['./principal.scss']
})

export class Principal implements OnInit {
  funcionarios: Funcionario[] = [];

  constructor(private funcService: FuncionariosService) { }

  ngOnInit(): void {
   this.funcService.listar().subscribe(response => {
   this.funcionarios = response.data;  
});
  }
}

