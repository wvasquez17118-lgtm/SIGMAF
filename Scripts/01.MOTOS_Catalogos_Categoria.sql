-- (Opcional) Crear la base de datos
-- CREATE DATABASE IF NOT EXISTS bd_motos;
-- USE bd_motos;

-- Tabla de categorías
CREATE TABLE moto_categoria (
    idcategoria INT AUTO_INCREMENT PRIMARY KEY,
    codigo      VARCHAR(20)  NOT NULL,
    descripcion VARCHAR(100) NOT NULL,
    estado      TINYINT(1)   NOT NULL DEFAULT 1,
    UNIQUE KEY uq_categoria_codigo (codigo)
) ENGINE=InnoDB;

-- Tabla de catálogo de motos
CREATE TABLE moto_catalogos (
    id          INT AUTO_INCREMENT PRIMARY KEY,
	codigo		VARCHAR(100) NOT NULL,
    nombre      VARCHAR(100) NOT NULL,
    descripcion VARCHAR(200) NULL,
    idcategoria INT NOT NULL,
    estado      TINYINT(1) NOT NULL DEFAULT 1,
    
    CONSTRAINT fk_moto_catalogos_categoria
        FOREIGN KEY (idcategoria)
        REFERENCES moto_categoria(idcategoria)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
) ENGINE=InnoDB;


CREATE TABLE moto_proveedores (
  proveedor_id   INT AUTO_INCREMENT PRIMARY KEY,
  nombre         VARCHAR(150) NOT NULL,
  celular       VARCHAR(50) NULL,
  direccion      VARCHAR(250) NULL,
  estado         TINYINT(1) NOT NULL DEFAULT 1,
  KEY idx_proveedores_nombre (nombre)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;


CREATE TABLE moto_compras (
  compra_id      BIGINT AUTO_INCREMENT PRIMARY KEY,
  fecha          DATE NOT NULL,
  proveedor_id   INT NOT NULL,
  tipo_factura   ENUM('CR','CO','FIA') NOT NULL COMMENT 'CR=Crédito, CO=Contado, FIA=Fiado',

  subtotal       DECIMAL(18,2) NOT NULL DEFAULT 0.00,
  descuento      DECIMAL(18,2) NOT NULL DEFAULT 0.00,
  total          DECIMAL(18,2) NOT NULL DEFAULT 0.00,

  observacion    VARCHAR(300) NULL,
  estado         TINYINT(1) NOT NULL DEFAULT 1,
  created_at     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  updated_at     DATETIME NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,

  KEY idx_compras_fecha (fecha),
  KEY idx_compras_proveedor (proveedor_id),

  CONSTRAINT fk_compras_proveedor
    FOREIGN KEY (proveedor_id)
    REFERENCES moto_proveedores (proveedor_id)
    ON UPDATE CASCADE
    ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;


CREATE TABLE moto_compras_detalle (
  compra_detalle_id BIGINT AUTO_INCREMENT PRIMARY KEY,
  compra_id         BIGINT NOT NULL,
  catalogo_id       INT NOT NULL,          -- FK a moto_catalogos.id (o tu tabla real)
  descripcion       VARCHAR(200) NULL,

  cantidad          DECIMAL(18,2) NOT NULL DEFAULT 0.00,
  precio_compra     DECIMAL(18,2) NOT NULL DEFAULT 0.00,
  precio_venta      DECIMAL(18,2) NOT NULL DEFAULT 0.00,

  estado            TINYINT(1) NOT NULL DEFAULT 1,

  KEY idx_detalle_compra (compra_id),
  KEY idx_detalle_catalogo (catalogo_id),

  CONSTRAINT fk_compras_detalle_compra
    FOREIGN KEY (compra_id)
    REFERENCES moto_compras (compra_id)
    ON UPDATE CASCADE
    ON DELETE CASCADE,

  CONSTRAINT fk_compras_detalle_catalogo
    FOREIGN KEY (catalogo_id)
    REFERENCES moto_catalogos (id)        -- <-- si tu tabla se llama distinto, cámbiala aquí
    ON UPDATE CASCADE
    ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;



CREATE TABLE motos_inventario_stock 
(
  inventario_stock_id BIGINT AUTO_INCREMENT PRIMARY KEY,
  catalogo_id INT NOT NULL,
  -- Stock
  stock_disponible     INT NOT NULL DEFAULT 0,  -- lo que realmente hay
  -- Precios vigentes (referencia rápida)
  precio_compra DECIMAL(18,2) NOT NULL DEFAULT 0.00,  -- último costo / costo referencia
  precio_venta  DECIMAL(18,2) NOT NULL DEFAULT 0.00,  -- precio de venta actual
  stock_minimo  INT NOT NULL DEFAULT 0,
  estado        TINYINT(1) NOT NULL DEFAULT 1,
  created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  UNIQUE KEY uq_inventario_catalogo (catalogo_id),
  CONSTRAINT fk_inventario_stock_catalogo
    FOREIGN KEY (catalogo_id)
    REFERENCES moto_catalogos(id)
    ON UPDATE CASCADE
    ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;



/* =========================================================
   TABLA: moto_ventas
   Basada en tu tabla ejemplo "ventas"
   Relación: moto_ventas.IdCatalogoProducto -> moto_catalogos.id
   ========================================================= */

 

CREATE TABLE moto_ventas (
  IdVenta               BIGINT AUTO_INCREMENT PRIMARY KEY,  
  IdCatalogoProducto    INT NOT NULL,
  NombreProducto        VARCHAR(150) NOT NULL,
  Cantidad              INT NULL,
  Precio                DOUBLE NULL,
  Total                 DOUBLE NULL,
  Descripcion           VARCHAR(255) NULL,
  DescripcionEliminado  VARCHAR(255) NULL,
  Estado                BIT NOT NULL DEFAULT b'1',

  FechaCreacion         DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  FechaModificacion     DATETIME NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,

  IdUsuarioCreacion     INT NOT NULL,
  IdUsuarioModificacion INT NULL,
  Sucursal              INT NULL COMMENT '1=Altalier, 2=Wama',
  KEY idx_moto_ventas_catalogo (IdCatalogoProducto),
  KEY idx_moto_ventas_fecha (FechaCreacion),

  CONSTRAINT fk_moto_ventas_catalogo
    FOREIGN KEY (IdCatalogoProducto)
    REFERENCES moto_catalogos(id)
    ON UPDATE CASCADE
    ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;




INSERT INTO moto_categoria VALUES (1,'RM','Repuestos moto',1);
INSERT INTO moto_categoria VALUES (2,'LUB','Lubricantes',1);
INSERT INTO moto_categoria VALUES (3,'ACC','Accesorios',1);
INSERT INTO moto_categoria VALUES (4,'LULED','Luces led',1);

INSERT INTO `moto_proveedores` (`proveedor_id`, `nombre`, `celular`, `direccion`, `estado`) 
VALUES (NULL, 'Don Juan', '77681415', NULL, '1'), (NULL, 'BTS', '-', NULL, '1');


 