using Newtonsoft.Json;
using Refit;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ElearningDesktop
{
    public class SerieQueryParameters
    {
        public string curso { get; set; }
        public string ano { get; set; }
        public string tipo { get; set; }
        public string periodo { get; set; }
    }

    public class TeacherQueryParameters
    {
        [AliasAs("rg")]
        public string RG { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("email")]
        public string Email { get; set; }

        [AliasAs("telefone")]
        public string Telefone { get; set; }

        [AliasAs("foto")]
        public string Foto { get; set; }
    }

    public class StudentQueryParameters
    {
        [AliasAs("telefone")]
        public string Telefone { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("email")]
        public string Email { get; set; }

        [AliasAs("foto")]
        public string Foto { get; set; }

        [AliasAs("idSerie")]
        public int IdSerie { get; set; }
    }

    public class ClassQueryParameters
    {
        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("icone")]
        public string Icone { get; set; }

        [AliasAs("corPrim")]
        public string CorPrim { get; set; }

        [AliasAs("corSec")]
        public string CorSec { get; set; }

        [AliasAs("idSerie")]
        public int? IdSerie { get; set; }

        [AliasAs("rgProfessor")]
        public int? RgProfessor { get; set; }
    }

    public class StudentQueryGet
    {
        [AliasAs("ra")]
        public int? RA { get; set; }

        [AliasAs("telefone")]
        public string Telefone { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("email")]
        public string Email { get; set; }

        [AliasAs("foto")]
        public string Foto { get; set; }

        [AliasAs("idSerie")]
        public int? IdSerie { get; set; }
    }

    public class ClassQueryGet
    {
        [AliasAs("id")]
        public int? ID { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("idSerie")]
        public int? IdSerie { get; set; }

        [AliasAs("rgProfessor")]
        public string RgProfessor { get; set; }
    }

    interface ApiService
    {
        #region Rotas de Séries
        [Get("/series/")]
        Task<dynamic> GetSeriesAsync();

        [Get("/series/")]
        Task<dynamic> GetSeriesFilteredAsync(SerieQueryParameters parametros);

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Post("/series/")]
        Task<dynamic> InsertSeriesAsync([Body] SerieQueryParameters parametros);
        #endregion

        #region Rotas de Professores
        [Get("/professores/")]
        Task<dynamic> GetTeachersAsync();

        [Get("/professores/")]
        Task<dynamic> GetTeachersFilteredAsync(TeacherQueryParameters parametros);

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Post("/professores/")]
        Task<dynamic> InsertTeachersAsync([Body] TeacherQueryParameters parametros);
        #endregion

        #region Rotas de Alunos
        [Get("/alunos/")]
        Task<dynamic> GetStudentsAsync();

        [Get("/alunos/")]
        Task<dynamic> GetStudentsFilteredAsync(StudentQueryGet parametros);

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Post("/alunos/")]
        Task<dynamic> InsertStudentsAsync([Body] StudentQueryParameters parametros);
        #endregion

        #region Rotas de Turmas
        [Get("/turmas/")]
        Task<dynamic> GetTurmasAsync();

        [Get("/turmas/")]
        Task<dynamic> GetTurmasFilteredAsync(ClassQueryGet parametros);

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Post("/turmas/")]
        Task<dynamic> InsertTurmasAsync([Body] ClassQueryParameters parametros);
        #endregion

        #region Enviar Imagem para Servidor
        [Multipart]
        [Post("/imagens/")]
        Task<dynamic> SendImageToApi( ByteArrayPart file);
        #endregion
    }
}