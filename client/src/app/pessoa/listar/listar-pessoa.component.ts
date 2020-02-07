import { Component, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { Pessoa } from 'src/app/models/pessoa.model';
import { PessoaService } from 'src/app/services/pessoa.service';
import { DeleteDialogComponent } from 'src/app/dialogs/delete/delete.dialog.component';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'listar-pessoa',
    templateUrl: './listar-pessoa.component.html',
    styleUrls: ['./listar-pessoa.component.scss']
})
export class ListarPessoaComponent {

    displayedColumns: string[] = ['nome', 'cpf', 'email', 'actions'];
    dataSource: MatTableDataSource<Pessoa>;
    @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: false }) sort: MatSort;
    @ViewChild('filter', { static: false }) filter: ElementRef;

    constructor(public httpClient: HttpClient,
        public dialog: MatDialog,
        public toster: ToastrService,
        public service: PessoaService) {

    }

    ngOnInit(): void {
        this.loadData();
    }

    refresh() {
        this.loadData();
    }

    applyFilter(filterValue: string) {
        this.dataSource.filter = filterValue.trim().toLowerCase();
    }

    public loadData() {

        this.service.obterPessoas()
            .subscribe(
                p => {
                    this.dataSource = new MatTableDataSource<Pessoa>(p);
                    this.dataSource.paginator = this.paginator;
                    this.dataSource.sort = this.sort;
                },
                error => {
                    this.toster.error("Erro ao obter pessoas.");
                });
    }

    deleteItem(id: number) {
        const dialogRef = this.dialog.open(DeleteDialogComponent, {
            data: { id: id }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result === 1) {
                this.toster.success("Pessoa removida com sucesso");
                this.refresh();
            }
        });
    }
}